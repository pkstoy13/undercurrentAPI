using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using undercurrentAPI.Data;
using undercurrentAPI.DTOs;
using undercurrentAPI.Models;
using AutoMapper;

namespace undercurrentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DiscoveryScoreController : ControllerBase
    {
        private readonly ArtistDbContext _context;
        private readonly IMapper _mapper;

        public DiscoveryScoreController(ArtistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DiscoveryScoreReadDTO>>> GetAllScores()
        {
            var scores = await _context.DiscoveryScores.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<DiscoveryScoreReadDTO>>(scores));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DiscoveryScoreReadDTO>> GetScoreById(Guid id)
        {
            var score = await _context.DiscoveryScores.FindAsync(id);

            if (score == null)
                return NotFound();

            return Ok(_mapper.Map<DiscoveryScoreReadDTO>(score));
        }

        [HttpPost]
        public async Task<ActionResult<DiscoveryScoreReadDTO>> CreateScore(DiscoveryScoreCreateDTO dto)
        {
            var score = _mapper.Map<DiscoveryScore>(dto);
            _context.DiscoveryScores.Add(score);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetScoreById), new { id = score.Id }, _mapper.Map<DiscoveryScoreReadDTO>(score));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateScore(Guid id, DiscoveryScoreUpdateDTO dto)
        {
            var score = await _context.DiscoveryScores.FindAsync(id);
            if (score == null)
                return NotFound();

            _mapper.Map(dto, score);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<DiscoveryScoreReadDTO>(score));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScore(Guid id)
        {
            var score = await _context.DiscoveryScores.FindAsync(id);
            if (score == null)
                return NotFound();

            _context.DiscoveryScores.Remove(score);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
