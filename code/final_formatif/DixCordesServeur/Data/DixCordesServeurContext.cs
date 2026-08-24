using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DixCordesServeur.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace DixCordesServeur.Data
{
    public class DixCordesServeurContext : IdentityDbContext<User>
    {
        public DixCordesServeurContext (DbContextOptions<DixCordesServeurContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "moderator", NormalizedName = "MODERATOR" }
            );

            PasswordHasher<User> hasher = new PasswordHasher<User>();

            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "a@a.a",
                NormalizedEmail = "A@A.A"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "salut");
            User u2 = new User
            {
                Id = "11111111-1111-1111-1111-111111111112",
                UserName = "sussyfella",
                NormalizedUserName = "SUSSYFELLA",
                Email = "s@s.s",
                NormalizedEmail = "S@S.S"
            };
            u2.PasswordHash = hasher.HashPassword(u2, "salut");

            builder.Entity<User>().HasData(u1, u2);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { UserId = u1.Id, RoleId = "1" }
            );

            builder.Entity<Channel>().HasData(
                new { Id = 1, Name = "général | 📢" },
                new { Id = 2, Name = "école | 😴" },
                new { Id = 3, Name = "nsfw | 🍑" }
            );

            builder.Entity<Message>().HasData(new
            {
                Id = 1,
                Text = "eske qqun peut me donner les réponses de l'exam svp ?",
                SentAt = new DateTime(2023, 5, 10, 20, 15, 27),
                ChannelId = 1,
                UserId = u2.Id
            }, new
            {
                Id = 2,
                Text = "Tu n'auras droit qu'à un seul avertissement @sussyfella : tu n'as pas utilisé le bon salon.",
                SentAt = new DateTime(2023, 5, 10, 20, 15, 31),
                ChannelId = 1,
                UserId = u1.Id
            }, new
            {
                Id = 3,
                Text = "Comment on fait déjà pour juste permettre au proprio d'un objet de le supprimer ? (Dans l'exam)",
                SentAt = new DateTime(2023, 5, 10, 21, 41, 17),
                ChannelId = 2,
                UserId = u1.Id
            }, new
            {
                Id = 4,
                Text = "g pas été capable de faire ce num la non plu xd pg g eu une bonne note à l'intra",
                SentAt = new DateTime(2023, 5, 10, 21, 42, 31),
                ChannelId = 2,
                UserId = u2.Id
            }, new
            {
                Id = 5,
                Text = "huh 👉👈",
                SentAt = new DateTime(2023, 5, 11, 18, 51, 2),
                ChannelId = 3,
                UserId = u2.Id
            });

            builder.Entity<Reaction>().HasData(new
            {
                Id = 1,
                FileName = "11111111-1111-1111-1111-111111111111.png",
                Quantity = 1,
                MimeType = "image/png",
                MessageId = 2
            }, new
            {
                Id = 2,
                FileName = "11111111-1111-1111-1111-111111111112.png",
                Quantity = 2,
                MimeType = "image/png",
                MessageId = 5
            });

            builder.Entity<Reaction>()
                .HasMany(r => r.Users)
                .WithMany(u => u.Reactions)
                .UsingEntity(e =>
                {
                    e.HasData(new { UsersId = u2.Id, ReactionsId = 1 });
                    e.HasData(new { UsersId = u1.Id, ReactionsId = 2 });
                    e.HasData(new { UsersId = u2.Id, ReactionsId = 2 });
                });
        }

        public DbSet<Channel> Channels { get; set; } = default!;
        public DbSet<Message> Messages { get; set; } = default!;
        public DbSet<Reaction> Reactions { get; set; } = default!;
    }
}
