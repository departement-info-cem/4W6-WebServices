using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serveur16.Data;
using serveur16.DTOs;
using serveur16.Models;

namespace serveur16.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly serveur16Context _context;
        private readonly UserManager<User> _userManager;

        public ReviewsController(serveur16Context context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<ActionResult> GetReview()
        {
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditReview(int id, ReviewDTO reviewDTO)
        {


            return Ok(new { Message = "Critique modifiée !" });
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpvoteReview(int id)
        {
           

            return Ok(/*new { Message = review.Upvoters.Contains(user) ? "Vote ajouté" : "Vote retiré" }*/);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostReview(ReviewDTO reviewDTO)
        {


            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteReview(int id)
        {


            return Ok(new { Message = "La critique a bien été supprimée" });
        }
    }
}
