using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vincible.Models;

namespace Vincible.Data
{
    public class VincibleContext : DbContext
    {
        public VincibleContext (DbContextOptions<VincibleContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Character>().HasData(
                new { Id = 1, Name = "Invincible", Img = "invincible", Age = 19, IsAlive = true },
                new { Id = 2, Name = "Atom Eve", Img = "atom_eve", Age = 19, IsAlive = true },
                new { Id = 3, Name = "Omni-Man", Img = "omni_man", Age = 2000, IsAlive = true },
                new { Id = 4, Name = "Allen the Alien", Img = "allen_the_alien", IsAlive = true },
                new { Id = 5, Name = "The Immortal", Img = "the_immortal", Age = 10000, IsAlive = true },
                new { Id = 6, Name = "Dupli-Kate", Img = "dupli_kate", IsAlive = true },
                new { Id = 7, Name = "Rex Splode", Img = "rex_splode", IsAlive = true },
                new { Id = 8, Name = "Monster Girl", Img = "monster_girl", Age = 26, IsAlive = true },
                new { Id = 9, Name = "Shrinking Rae", Img = "shrinking_rae", IsAlive = true },
                new { Id = 10, Name = "Multi-Paul", Img = "multi_paul", IsAlive = true },
                new { Id = 11, Name = "Powerplex", Img = "powerplex", IsAlive = true },
                new { Id = 12, Name = "Red Rush", Img = "red_rush", IsAlive = false },
                new { Id = 13, Name = "Robot", Img = "robot", Age = 12, IsAlive = true },
                new { Id = 14, Name = "Shapesmith", Img = "shapesmith", IsAlive = true },
                new { Id = 15, Name = "War Woman", Img = "war_woman", IsAlive = false }
            );

            builder.Entity<Superpower>().HasData(
                new { Id = 1, Name = "Vol", Description = "L'utilisateur peut voler ou léviter." },
                new { Id = 2, Name = "Invulnérabilité", Description = "L'utilisateur est significativement résistant contre la majorité des menaces physiques." },
                new { Id = 3, Name = "Régénération", Description = "L'utilisateur guérit significativement rapidement de ses blessures." },
                new { Id = 4, Name = "Vitesse surhumaine", Description = "L'utilisateur peut se déplacer significativement rapidement." },
                new { Id = 5, Name = "Force surhumaine", Description = "L'utilisateur possède une force physique significativement grande." },
                new { Id = 6, Name = "Manipulation de la matière", Description = "L'utilisateur peut manipuler la matière à un niveau moléculaire et atomique." },
                new { Id = 7, Name = "Résurrection", Description = "L'utilisateur, même si cliniquement mort, peut se regénérer et reprendre vie." },
                new { Id = 8, Name = "Réplication", Description = "L'utilisateur peut dupliquer son corps tout en gardant le contrôle de chacun." },
                new { Id = 9, Name = "Charge cinétique", Description = "L'utilisateur peut créer de l'énergie cinétique et la transférer sur des objets pour les faire exploser." },
                new { Id = 10, Name = "Transformation", Description = "L'utilisateur peut se transformer ou se métamorphoser." },
                new { Id = 11, Name = "Réduction de taille", Description = "L'utilisateur peut réduire et augmenter sa taille sans dépasser sa taille naturelle." },
                new { Id = 12, Name = "Absorbtion d'énergie", Description = "L'utilisateur peut absorber l'énergie cinétique des objets." }
            );

            builder.Entity<Character>()
                .HasMany(c => c.Superpowers)
                .WithMany(s => s.Characters)
                .UsingEntity(e => {
                    // Invincible
                    e.HasData(new { CharactersId = 1, SuperpowersId = 1 });
                    e.HasData(new { CharactersId = 1, SuperpowersId = 2 });
                    e.HasData(new { CharactersId = 1, SuperpowersId = 3 });
                    e.HasData(new { CharactersId = 1, SuperpowersId = 4 });
                    e.HasData(new { CharactersId = 1, SuperpowersId = 5 });
                    // Atom Eve
                    e.HasData(new { CharactersId = 2, SuperpowersId = 6 });
                    // Omni-Man
                    e.HasData(new { CharactersId = 3, SuperpowersId = 1 });
                    e.HasData(new { CharactersId = 3, SuperpowersId = 2 });
                    e.HasData(new { CharactersId = 3, SuperpowersId = 3 });
                    e.HasData(new { CharactersId = 3, SuperpowersId = 4 });
                    e.HasData(new { CharactersId = 3, SuperpowersId = 5 });
                    // Allen the Alien
                    e.HasData(new { CharactersId = 4, SuperpowersId = 1 });
                    e.HasData(new { CharactersId = 4, SuperpowersId = 2 });
                    e.HasData(new { CharactersId = 4, SuperpowersId = 3 });
                    e.HasData(new { CharactersId = 4, SuperpowersId = 4 });
                    e.HasData(new { CharactersId = 4, SuperpowersId = 5 });
                    // The Immortal
                    e.HasData(new { CharactersId = 5, SuperpowersId = 1 });
                    e.HasData(new { CharactersId = 5, SuperpowersId = 2 });
                    e.HasData(new { CharactersId = 5, SuperpowersId = 3 });
                    e.HasData(new { CharactersId = 5, SuperpowersId = 4 });
                    e.HasData(new { CharactersId = 5, SuperpowersId = 5 });
                    e.HasData(new { CharactersId = 5, SuperpowersId = 7 });
                    // Dupli-Kate
                    e.HasData(new { CharactersId = 6, SuperpowersId = 8 });
                    // Rex Splode
                    e.HasData(new { CharactersId = 7, SuperpowersId = 9 });
                    // Monster Girl
                    e.HasData(new { CharactersId = 8, SuperpowersId = 10 });
                    e.HasData(new { CharactersId = 8, SuperpowersId = 3 });
                    e.HasData(new { CharactersId = 8, SuperpowersId = 4 });
                    e.HasData(new { CharactersId = 8, SuperpowersId = 5 });
                    // Shrinking Rae
                    e.HasData(new { CharactersId = 9, SuperpowersId = 11 });
                    // Multi-Paul
                    e.HasData(new { CharactersId = 10, SuperpowersId = 8 });
                    // Powerplex
                    e.HasData(new { CharactersId = 11, SuperpowersId = 2 });
                    e.HasData(new { CharactersId = 11, SuperpowersId = 5 });
                    e.HasData(new { CharactersId = 11, SuperpowersId = 12 });
                    // Red Rush
                    e.HasData(new { CharactersId = 12, SuperpowersId = 4 });
                    // Robot (aucun)
                    // Shapesmith
                    e.HasData(new { CharactersId = 14, SuperpowersId = 10 });
                    // War Woman
                    e.HasData(new { CharactersId = 15, SuperpowersId = 1 });
                    e.HasData(new { CharactersId = 15, SuperpowersId = 2 });
                    e.HasData(new { CharactersId = 15, SuperpowersId = 4 });
                    e.HasData(new { CharactersId = 15, SuperpowersId = 5 });
                });
        }

        public DbSet<Character> Characters { get; set; } = default!;
        public DbSet<Superpower> Superpowers { get; set; } = default!;
    }
}
