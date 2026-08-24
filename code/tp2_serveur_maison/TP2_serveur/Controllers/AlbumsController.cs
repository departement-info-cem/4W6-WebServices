using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2_serveur.Data;
using TP2_serveur.Models;

namespace TP2_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly TP2_serveurContext _context;

        public AlbumsController(TP2_serveurContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums(int id)
        {
            Artist? artist = await _context.Artist.FindAsync(id);
            if (artist == null) return NotFound(new { Message = "Aucun artiste n'existe avec cet id : " + id});
            return Ok(artist.Albums);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPicture(int id)
        {
            Album? a = await _context.Album.FindAsync(id);
            if (a == null) return NotFound();

            byte[] bytes = System.IO.File.ReadAllBytes(Directory.GetCurrentDirectory() + "/images/albums/" + id + ".png");
            return File(bytes, "image/png");
        }
    }
}
