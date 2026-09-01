
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labo6_serveur.Data;
using labo6_serveur.Models;

namespace labo6_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly labo6_serveurContext _context;
        private readonly Random _random = new Random();

        public QuestionsController(labo6_serveurContext context)
        {
            _context = context;
        }

        [HttpGet("{quantity}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(int quantity)
        {
            if (quantity > 10) quantity = 10;

            int count = await _context.Question.CountAsync();
            int[] indexes = new int[quantity];

            for (int i = 0; i < indexes.Length; i++)
            {
                int index = -1;

                while (index == -1 || indexes.Contains(index))
                {
                    index = _random.Next(0, count);
                }

                indexes[i] = index;
            }

            return await _context.Question.Where(q => indexes.Contains(q.Id)).ToListAsync();
        }
    }
}
