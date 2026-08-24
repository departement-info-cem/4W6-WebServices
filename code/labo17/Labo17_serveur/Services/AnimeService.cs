using Labo17_serveur.Data;
using Labo17_serveur.Models;
using Microsoft.EntityFrameworkCore;

namespace Labo17_serveur.Services
{
    public class AnimeService
    {
        private readonly Labo17_serveurContext _context;

        public AnimeService(Labo17_serveurContext context)
        {
            _context = context;
        }

        public async Task<Anime?> GetOne(int id)
        {
            return await _context.Anime.FindAsync(id);
        }

        public async Task<IEnumerable<Anime>> GetAll()
        {
            return await _context.Anime.ToListAsync();
        }

        public async Task Create(Anime anime)
        {
            // À compléter



        }

        public async Task<bool> Subscribe(Anime anime, User user)
        {
            // À compléter


            
            // À modifier
            return false;
        }
    }
}
