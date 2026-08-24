
using DixCordesServeur.Data;
using DixCordesServeur.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DixCordesServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ChannelsController : ControllerBase
    {
        private readonly DixCordesServeurContext _context;
        private readonly UserManager<User> _userManager;

        public ChannelsController(DixCordesServeurContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Channel>>> GetChannel()
        {
            if (_context.Channels == null)
            {
                return NotFound();
            }
            return await _context.Channels.ToListAsync();
        }
    }
}
