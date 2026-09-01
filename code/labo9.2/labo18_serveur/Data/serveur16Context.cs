using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using serveur16.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace serveur16.Data
{
    public class serveur16Context : IdentityDbContext<User>
    {
        public serveur16Context (DbContextOptions<serveur16Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111", UserName = "bob", Email = "b@b.b", NormalizedUserName = "BOB", NormalizedEmail = "B@B.B"
            };

            u1.PasswordHash = hasher.HashPassword(u1, "allo");
            builder.Entity<User>().HasData(u1);

            builder.Entity<Review>().HasData(
                new { Id = 1, Game = "Cyberpunk 2077", Text = "C'parce que lé bonhommes font des T poses pis y rentrer dans le plancher des fois xd", AuthorId = u1.Id },
                new { Id = 2, Game = "Mario Kart World", Text = "Je préfère de loin Garfield Kart !", AuthorId = u1.Id }
            );
        }

        public DbSet<Review> Review { get; set; } = default!;
    }
}
