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
    public class PlatformAccountController : ControllerBase
    {
        private readonly ArtistDbContext _context;
        private readonly IMapper _mapper;

        public PlatformAccountController(ArtistDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET all PlatformAccounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformAccountReadDTO>>> GetPlatformAccounts()
        {
            var platformAccounts = await _context.PlatformAccounts.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<PlatformAccountReadDTO>>(platformAccounts));
        }

        // GET PlatformAccount by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<PlatformAccountReadDTO>> GetPlatformAccountById(Guid id)
        {
            var platformAccount = await _context.PlatformAccounts.FindAsync(id);
            if (platformAccount == null) return NotFound();

            return Ok(_mapper.Map<PlatformAccountReadDTO>(platformAccount));
        }

        // POST PlatformAccount
        [HttpPost]
        public async Task<ActionResult<PlatformAccountReadDTO>> CreatePlatformAccount(PlatformAccountCreateDTO dto)
        {
            var platformAccount = _mapper.Map<PlatformAccount>(dto);
            platformAccount.Id = Guid.NewGuid();

            _context.PlatformAccounts.Add(platformAccount);
            await _context.SaveChangesAsync();

            var readDTO = _mapper.Map<PlatformAccountReadDTO>(platformAccount);

            return CreatedAtAction(nameof(GetPlatformAccountById), new { id = readDTO.Id }, readDTO);
        }

        // PATCH PlatformAccount
        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdatePlatformAccount(Guid id, PlatformAccountUpdateDTO dto)
        {
            var platformAccount = await _context.PlatformAccounts.FindAsync(id);
            if (platformAccount == null) return NotFound();

            _mapper.Map(dto, platformAccount);
            await _context.SaveChangesAsync();

            return Ok(_mapper.Map<PlatformAccountReadDTO>(platformAccount));
        }

        // DELETE PlatformAccount
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePlatformAccount(Guid id)
        {
            var platformAccount = await _context.PlatformAccounts.FindAsync(id);
            if (platformAccount == null) return NotFound();

            _context.PlatformAccounts.Remove(platformAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }

}