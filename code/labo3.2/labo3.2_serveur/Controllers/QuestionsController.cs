
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using labo32_serveur.Data;
using labo32_serveur.Models;

namespace labo32_serveur.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuestionsController(labo32_serveurContext context) : ControllerBase
    {
        private readonly Random _random = new Random();

        [HttpGet("{quantity}")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestions(int quantity)
        {
            if (quantity > 10) quantity = 10;

            int count = await context.Question.CountAsync();
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

            return await context.Question.Where(q => indexes.Contains(q.Id)).ToListAsync();
        }
    }
}
