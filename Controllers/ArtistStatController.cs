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
    public class ArtistStatController : ControllerBase
    {
        private readonly ArtistDbContext _context;
        private readonly IMapper _mapper;

        public ArtistStatController(ArtistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArtistStatReadDTO>>> GetAllStats()
        {
            var stats = await _context.ArtistStats.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<ArtistStatReadDTO>>(stats));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ArtistStatReadDTO>> GetStatById(Guid id)
        {
            var stat = await _context.ArtistStats.FindAsync(id);
            if (stat == null) return NotFound();

            return Ok(_mapper.Map<ArtistStatReadDTO>(stat));
        }

        [HttpPost]
        public async Task<ActionResult<ArtistStatReadDTO>> CreateStat(ArtistStatCreateDTO dto)
        {
            var stat = _mapper.Map<ArtistStat>(dto);
            stat.Id = Guid.NewGuid();
            _context.ArtistStats.Add(stat);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStatById), new { id = stat.Id }, _mapper.Map<ArtistStatReadDTO>(stat));
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateStat(Guid id, ArtistStatUpdateDTO dto)
        {
            var stat = await _context.ArtistStats.FindAsync(id);
            if (stat == null) return NotFound();

            _mapper.Map(dto, stat);
            await _context.SaveChangesAsync();
            return Ok(_mapper.Map<ArtistStatReadDTO>(stat));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStat(Guid id)
        {
            var stat = await _context.ArtistStats.FindAsync(id);
            if (stat == null) return NotFound();

            _context.ArtistStats.Remove(stat);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }

}