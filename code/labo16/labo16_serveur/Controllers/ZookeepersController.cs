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
    public class ZookeepersController : ControllerBase
    {
        private readonly serveur15Context _context;

        public ZookeepersController(serveur15Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zookeeper>>> GetZookeeper()
        {
            return await _context.Zookeeper.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Zookeeper>> PostZookeeper(Zookeeper zookeeper)
        {
            _context.Zookeeper.Add(zookeeper);
            await _context.SaveChangesAsync();

            return Ok(zookeeper);
        }

        // DeleteZookeeper
    }
}
