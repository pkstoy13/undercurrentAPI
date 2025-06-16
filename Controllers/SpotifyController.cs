using Microsoft.AspNetCore.Mvc;
using undercurrentAPI.Services;

namespace undercurrentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SpotifyController : ControllerBase
    {
        private readonly SpotifyAuthService _spotifyAuthService;
        private readonly SpotifyApiService _spotifyApiService;

        public SpotifyController(SpotifyAuthService spotifyAuthService, SpotifyApiService spotifyApiService)
        {
            _spotifyAuthService = spotifyAuthService;
            _spotifyApiService = spotifyApiService;
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

            return Ok(result.RootElement);
        }

    }

    
}
