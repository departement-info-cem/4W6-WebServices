using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Labo17_serveur.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Labo17_serveur.Data
{
    public class Labo17_serveurContext : IdentityDbContext<User>
    {
        public Labo17_serveurContext (DbContextOptions<Labo17_serveurContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Anime>().HasData(
                new { Id = 1, Name = "Delicious in Dungeon", Genres = new List<string> { "adventure", "cooking", "comedy" }, ImageUrl = "https://resizing.flixster.com/EB1K0hi-UehqbpbBW2QOaeOnmTU=/ems.cHJkLWVtcy1hc3NldHMvdHZzZWFzb24vMzMyNjkxOGUtZGY5OC00ODk3LWE0MTAtNjU4NzZhZDU1NzEzLmpwZw==" },
                new { Id = 2, Name = "Attack on Titan", Genres = new List<string> { "dark fantasy", "action", "shonen" }, ImageUrl = "https://preview.redd.it/is-attack-on-titan-a-good-entry-level-anime-for-someone-v0-970wisbt9n7f1.jpg?width=500&format=pjpg&auto=webp&s=9dbd987658030890aa6a962b0c0cf9d9b4729473" },
                new { Id = 3, Name = "One Piece", Genres = new List<string>{ "shonen", "action", "fantasy" }, ImageUrl = "https://m.media-amazon.com/images/M/MV5BMTNjNGU4NTUtYmVjMy00YjRiLTkxMWUtNzZkMDNiYjZhNmViXkEyXkFqcGc@._V1_FMjpg_UX1000_.jpg" }
            );
        }

        public DbSet<Anime> Anime { get; set; } = default!;
    }
}
