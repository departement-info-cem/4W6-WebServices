using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP2_serveur.Data;
using TP2_serveur.Models;

namespace TP2_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly TP2_serveurContext _context;

        public ArtistsController(TP2_serveurContext context)
        {
            _context = context;
        }

        [HttpGet("{name}")]
        [Authorize]
        public async Task<ActionResult<Artist>> GetArtist(string name)
        {
            Artist? artist = await _context.Artist.FirstOrDefaultAsync(a => a.Name.ToUpper() == name.ToUpper());

            if (artist == null) return NotFound(new {Message = "Aucun artiste trouvé avec ce nom. Vérifiez l'orthographe."});

            return artist;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPicture(int id)
        {
            Artist? a = await _context.Artist.FindAsync(id);
            if (a == null) return NotFound();

            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/artists/" + id + ".png");
            return File(bytes, "image/png");
        }
    }
}
