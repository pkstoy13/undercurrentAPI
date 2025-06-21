using Microsoft.AspNetCore.Mvc;
using undercurrentAPI.Services;
using undercurrentAPI.Models;
using undercurrentAPI.Mappings;
using Microsoft.EntityFrameworkCore;
using undercurrentAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using undercurrentAPI.DTOs;

namespace undercurrentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly SpotifyAuthService _spotifyAuthService;
        private readonly SpotifyApiService _spotifyApiService;
        private readonly ArtistDbContext _context;

        public SpotifyController(
            SpotifyAuthService spotifyAuthService,
            SpotifyApiService spotifyApiService,
            ArtistDbContext context)
        {
            _spotifyAuthService = spotifyAuthService;
            _spotifyApiService = spotifyApiService;
            _context = context;
        }

        [HttpGet("token")]
        public async Task<IActionResult> GetToken()
        {
            var token = await _spotifyAuthService.GetAccessTokenAsync();
            if (token == null)
                return StatusCode(500, "Failed to get access token from Spotify.");

            return Ok(new { access_token = token });
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchArtists([FromQuery] string name)
        {
            var result = await _spotifyApiService.SearchArtistsAsync(name);
            if (result == null)
                return StatusCode(500, "Spotify API call failed.");

            // Don't use RootElement — return a trimmed version or the whole object
            return Ok(result.Artists.Items);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportArtistsFromSpotify([FromQuery] string name)
        {
            var searchResponse = await _spotifyApiService.SearchArtistsAsync(name);

            if (searchResponse?.Artists?.Items == null || !searchResponse.Artists.Items.Any())
                return NotFound("No artists found.");

            var createdArtists = new List<Artist>();

            foreach (var spArtist in searchResponse.Artists.Items)
            {
                var (artist, platformAccount) = SpotifyMapper.MapSpotifyArtistToModels(spArtist);

                var exists = await _context.PlatformAccounts
                    .AnyAsync(pa => pa.ExternalId == platformAccount.ExternalId);

                if (exists) continue;

                _context.Artists.Add(artist);
                _context.PlatformAccounts.Add(platformAccount);
                
                var stat = SpotifyMapper.MapToArtistStat(spArtist, platformAccount.Id);
                _context.ArtistStats.Add(stat);

                createdArtists.Add(artist);
            }


            await _context.SaveChangesAsync();

            return Ok(createdArtists.Select(a => new ArtistReadDTO
            {
                Id = a.Id,
                Name = a.Name
            }).ToList());

            }
    }
}
