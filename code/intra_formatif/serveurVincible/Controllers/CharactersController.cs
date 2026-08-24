
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vincible.Data;
using Vincible.Models;
using Vincible.Models.DTOs;

namespace Vincible.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly VincibleContext _context;

        public CharactersController(VincibleContext context)
        {
            _context = context;
        }

        /*[HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            return await _context.Characters.Select(c => new CharacterDTO(c)).ToListAsync();
        }*/

        [HttpGet("{power}")]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharactersByPower(string power)
        {
            var superpower = await _context.Superpowers.Include(s => s.Characters).FirstOrDefaultAsync(s => s.Name.ToLower() == power.ToLower());
            if (superpower == null) return NotFound();

            return Ok(superpower.Characters.Select(c => new CharacterDTO(c)).ToList());
        }

        /*[HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacterById(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null) return NotFound();

            return Ok(new CharacterDTO(character));
        }*/

        [HttpGet("{name}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacterByName(string name)
        {
            var character = await _context.Characters.Include(c => c.Superpowers).FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());

            if (character == null) return NotFound();

            return Ok(new CharacterDTO(character));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPicture(int id)
        {
            var character = await _context.Characters.FindAsync(id);

            if (character == null) return NotFound();

            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/" + character.Img + ".png");
            return File(bytes, "images/png");
        }
    }
}
