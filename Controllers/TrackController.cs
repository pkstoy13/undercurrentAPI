using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using undercurrentAPI.Data;
using undercurrentAPI.Models;
using undercurrentAPI.DTOs;


namespace undercurrentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : ControllerBase
    {
        private readonly ArtistDbContext _context;
        private readonly IMapper _mapper;

        public TrackController(ArtistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrackReadDTO>>> GetAllTracks()
        {
            var tracks = await _context.Tracks.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<TrackReadDTO>>(tracks));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TrackReadDTO>> GetTrackById(Guid id)
        {
            var track = await _context.Tracks.FindAsync(id);

            if (track == null)
                return NotFound();

            return Ok(_mapper.Map<TrackReadDTO>(track));
        }

        [HttpPost]
        public async Task<ActionResult<TrackReadDTO>> CreateTrack(TrackCreateDTO dto)
        {
            var track = _mapper.Map<Track>(dto);
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrackById), new { id = track.Id }, _mapper.Map<TrackReadDTO>(track));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTrack(Guid id, TrackUpdateDTO dto)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
                return NotFound();

            _mapper.Map(dto, track);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<TrackReadDTO>(track));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrack(Guid id)
        {
            var track = await _context.Tracks.FindAsync(id);
            if (track == null)
                return NotFound();

            _context.Tracks.Remove(track);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}