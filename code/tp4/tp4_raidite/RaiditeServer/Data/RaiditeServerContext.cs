using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaiditeServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaiditeServer.Data
{
    public class RaiditeServerContext : IdentityDbContext<User>
    {
        public RaiditeServerContext (DbContextOptions<RaiditeServerContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Deux utilisateurs 
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "bob",
                Email = "b@b.b",
                NormalizedUserName = "BOB",
                NormalizedEmail = "B@B.B",
                ConcurrencyStamp = "5a5312ef-f518-4e4e-bc30-2ae911f12453",
                SecurityStamp = "58dbf575-0aaf-42b2-8cf4-290f3d3c5d68",
                PasswordHash = "AQAAAAIAAYagAAAAEKIgA9m6keJl7lVJy0SGmmBMjS2DzpM5dgsmmERUQhtBCQzuZn+T4R4X0fvD6qH9IQ=="
            };
            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "tom",
                Email = "t@t.t",
                NormalizedUserName = "TOM",
                NormalizedEmail = "T@T.T",
                ConcurrencyStamp = "999f283d-f482-493b-ae73-95e6c212c45f",
                SecurityStamp = "195b4591-0449-4ee1-accd-885ababb4c50",
                PasswordHash = "AQAAAAIAAYagAAAAEDsGoHNO8yuobjXITN5pM5fcvQ9KT+e3YBxUZqkjknSSwcVslnBS0mmykjCbGRe9DQ=="
            };

            builder.Entity<User>().HasData(u1, u2);

        }

        public DbSet<Hub> Hub { get; set; } = default!;
        public DbSet<Comment> Comment { get; set; } = default!;
        public DbSet<Picture> Picture { get; set; } = default!;
        public DbSet<Post> Post { get; set; } = default!;
    }
}
