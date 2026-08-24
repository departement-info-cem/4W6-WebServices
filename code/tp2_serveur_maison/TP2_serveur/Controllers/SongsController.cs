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
    public class SongsController : ControllerBase
    {
        private readonly TP2_serveurContext _context;

        public SongsController(TP2_serveurContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Song>>> GetSongs(int id)
        {
            Album? a = await _context.Album.FindAsync(id);
            if (a == null) return NotFound(new { Message = "Aucun album n'existe avec cet id : " + id });
            return Ok(a.Songs);
        }
    }
}
