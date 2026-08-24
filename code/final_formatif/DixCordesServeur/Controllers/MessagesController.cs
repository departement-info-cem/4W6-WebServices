
using DixCordesServeur.Data;
using DixCordesServeur.DTOs;
using DixCordesServeur.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace DixCordesServeur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly DixCordesServeurContext _context;
        private readonly UserManager<User> _userManager;

        public MessagesController(DixCordesServeurContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet("{channelId}")]
        public async Task<IActionResult> GetChannelMessages(int channelId)
        {
            if(_context.Messages == null || _context.Channels == null)
            {
                return Problem("Entity set 'Messages' is null.");
            }

            Channel? channel = await _context.Channels.FindAsync(channelId);
            if(channel == null || channel.Messages == null)
            {
                return Ok(new List<Message>());
            }
            else
            {
                User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

                // Les messages du channel sont transformés en MessageDisplayDTOs, pour ajouter le nom de l'utilisateur pour chaque message.
                return Ok(channel.Messages.Select(x => new MessageDisplayDTO(x, user)));
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostMessage(PostMessageDTO messageDTO)
        {
            if (_context.Messages == null || _context.Channels == null) return Problem("Entity set 'Messages' is null.");

            User? user = await _userManager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            Channel? channel = await _context.Channels.FindAsync(messageDTO.ChannelId);

            if(channel == null || user == null)
            {
                return NotFound(new { Message = "Ce channel n'existe pas." });
            }

            Message message = new Message() { Id = 0, Text = messageDTO.Text, Channel = channel, User = user, SentAt = DateTime.Now };

            _context.Messages.Add(message);
            await _context.SaveChangesAsync();

            MessageDisplayDTO returnMessage = new MessageDisplayDTO(message, user);

            return Ok(returnMessage);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            // À compléter
            

            return NoContent();
        }
    }
}
