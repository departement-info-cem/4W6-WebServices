using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using serveur21.Models;

namespace serveur21.Data
{
    public class serveur21Context : IdentityDbContext<User>
    {
        public serveur21Context (DbContextOptions<serveur21Context> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            // Utilisateur(s)
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111", UserName = "Maxou", Email = "m@m.m",
                NormalizedUserName = "MAXOU", NormalizedEmail = "M@M.M"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "allo");

            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-111111111112", UserName = "Pielle-Arexandre", Email = "p@p.p",
                NormalizedUserName = "PIELLE-AREXANDRE", NormalizedEmail = "P@P.P"
            };
            u2.PasswordHash = hasher.HashPassword(u2, "allo");

            User u3 = new User
            {
                Id = "11111111-1111-1111-1111-111111111113", UserName = "Masie-Carrandra", Email = "c@c.c",
                NormalizedUserName = "MASIE-CARRANDRA", NormalizedEmail = "C@C.C"
            };
            u3.PasswordHash = hasher.HashPassword(u3, "allo");

            builder.Entity<User>().HasData(u1, u2, u3);
        }

        public DbSet<Review> Review { get; set; } = default!;
    }
}
