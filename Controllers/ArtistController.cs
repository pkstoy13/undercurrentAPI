using System.Data;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using undercurrentAPI.Data;
using undercurrentAPI.Models;
using undercurrentAPI.DTOs;

namespace undercurrentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArtistController : ControllerBase
    {
        private readonly ArtistDbContext _context;
        private readonly IMapper _mapper;

        public ArtistController(ArtistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/artists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistReadDTO>>> GetAllArtists()
        {
            var artists = await _context.Artists.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ArtistReadDTO>>(artists));
        }

        // GET: api/artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artist>> GetArtistById(Guid id)
        {
            var artist = await _context.Artists.FindAsync(id);

            if (artist == null)
            {
                return NotFound();
            }

            return artist;
        }

        //create a new artist
        [HttpPost]
        public async Task<ActionResult<ArtistReadDTO>> CreateArtist(ArtistCreateDTO dto)
        {
            var artist = _mapper.Map<Artist>(dto);
            artist.Id = Guid.NewGuid();
            artist.CreatedAt = DateTime.UtcNow;

            _context.Artists.Add(artist);
            await _context.SaveChangesAsync();

            var readDto = _mapper.Map<ArtistReadDTO>(artist);
            return CreatedAtAction(nameof(GetAllArtists), new { id = artist.Id }, readDto);
        }

        //edit an artist
        [HttpPut]
        public async Task<IActionResult> EditArtist(Guid id, Artist artist)
        {
            if (id != artist.Id) return BadRequest("Id not found");
            _context.Entry(artist).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DBConcurrencyException)
            {
                if (!ArtistExists(id)) return NotFound();
                else throw;
            }
            return NoContent();
        }

        //delete an Artist
        [HttpDelete]
        public async Task<IActionResult> DeleteArtist(Guid id)
        {
            var artist = await _context.Artists.FindAsync(id);
            if (artist == null) return NotFound();

            _context.Artists.Remove(artist);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        
         private bool ArtistExists(Guid id) =>
            _context.Artists.Any(e => e.Id == id);
    }
    }



