using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serveur15.Data;
using serveur15.Models;

namespace serveur15.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DinosaursController : ControllerBase
    {
        private readonly serveur15Context _context;

        public DinosaursController(serveur15Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dinosaur>>> GetDinosaur()
        {
            return await _context.Dinosaur.ToListAsync();
        }

        // PostDinosaur

        // DeleteDinosaur
    }
}
