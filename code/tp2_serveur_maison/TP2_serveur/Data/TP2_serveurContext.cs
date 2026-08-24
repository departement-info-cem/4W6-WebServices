using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TP2_serveur.Models;

namespace TP2_serveur.Data
{
    public class TP2_serveurContext : IdentityDbContext<User>
    {
        public TP2_serveurContext (DbContextOptions<TP2_serveurContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            User u1 = new User
            {
                Id = "11111111-1111-1111-1111-111111111111", UserName = "abc", Email = "a@a.a", NormalizedUserName = "ABC", NormalizedEmail = "A@A.A"
            };
            u1.PasswordHash = hasher.HashPassword(u1, "123");
            builder.Entity<User>().HasData(u1);

            CreateArtists(builder);
            CreateAlbums(builder);
            CreateSongs(builder);
        }

        #region seed
        private void CreateArtists(ModelBuilder builder)
        {
            string domain = "http://localhost:5143/api/Artists/GetPicture/";

            builder.Entity<Artist>().HasData(
                new { Id = 1, Name = "Hans Zimmer", ImageUrl = domain + 1 },
                new { Id = 2, Name = "The Weeknd", ImageUrl = domain + 2 },
                new { Id = 3, Name = "Drake", ImageUrl = domain + 3 },
                new { Id = 4, Name = "Lady Gaga", ImageUrl = domain + 4 },
                new { Id = 5, Name = "Beyoncé", ImageUrl = domain + 5 }
            );
        }

        private void CreateAlbums(ModelBuilder builder)
        {
            string domain = "http://localhost:5143/api/Albums/GetPicture/";

            builder.Entity<Album>().HasData(
                new { Id = 1, Name = "Interstellar", ImageUrl = domain + 1, ArtistId = 1 },
                new { Id = 2, Name = "Inception", ImageUrl = domain + 2, ArtistId = 1 },
                new { Id = 3, Name = "Dune", ImageUrl = domain + 3, ArtistId = 1 },
                new { Id = 4, Name = "Twilight of the Gods", ImageUrl = domain + 4, ArtistId = 1 },
                new { Id = 5, Name = "Starboy", ImageUrl = domain + 5, ArtistId = 2 },
                new { Id = 6, Name = "After Hours", ImageUrl = domain + 6, ArtistId = 2 },
                new { Id = 7, Name = "Hurry Up Tomorrow", ImageUrl = domain + 7, ArtistId = 2 },
                new { Id = 8, Name = "Dawn FM", ImageUrl = domain + 8, ArtistId = 2 },
                new { Id = 9, Name = "Views", ImageUrl = domain + 9, ArtistId = 3 },
                new { Id = 10, Name = "Certified Lover Boy", ImageUrl = domain + 10, ArtistId = 3 },
                new { Id = 11, Name = "Scorpion", ImageUrl = domain + 11, ArtistId = 3 },
                new { Id = 12, Name = "For All the Dogs", ImageUrl = domain + 12, ArtistId = 3 },
                new { Id = 13, Name = "Mayhem", ImageUrl = domain + 13, ArtistId = 4 },
                new { Id = 14, Name = "The Fame", ImageUrl = domain + 14, ArtistId = 4 },
                new { Id = 15, Name = "Artpop", ImageUrl = domain + 15, ArtistId = 4 },
                new { Id = 16, Name = "Chromatica", ImageUrl = domain + 16, ArtistId = 4 },
                new { Id = 17, Name = "Cowboy Carter", ImageUrl = domain + 17, ArtistId = 5 },
                new { Id = 18, Name = "Lemonade", ImageUrl = domain + 18, ArtistId = 5 },
                new { Id = 19, Name = "4", ImageUrl = domain + 19, ArtistId = 5 },
                new { Id = 20, Name = "B'Day", ImageUrl = domain + 20, ArtistId = 5 }
            );
        }

        private void CreateSongs(ModelBuilder builder)
        {
            builder.Entity<Song>().HasData(
                new { Id = 1, Name = "Cornfield Chase", AlbumId = 1 },
                new { Id = 2, Name = "Mountains", AlbumId = 1 },
                new { Id = 3, Name = "Afraid of Time", AlbumId = 1 },
                new { Id = 4, Name = "Old Souls", AlbumId = 2 },
                new { Id = 5, Name = "Dream Within a Dream", AlbumId = 2 },
                new { Id = 6, Name = "Mombasa", AlbumId = 2 },
                new { Id = 7, Name = "Dream of Arrakis", AlbumId = 3 },
                new { Id = 8, Name = "House Atreides", AlbumId = 3 },
                new { Id = 9, Name = "Leaving Caladan", AlbumId = 3 },
                new { Id = 10, Name = "Valhalla", AlbumId = 4 },
                new { Id = 11, Name = "Open Hands", AlbumId = 4 },
                new { Id = 12, Name = "Tricky Lover", AlbumId = 4 },
                new { Id = 13, Name = "Starboy", AlbumId = 5 },
                new { Id = 14, Name = "Party Monster", AlbumId = 5 },
                new { Id = 15, Name = "Secrets", AlbumId = 5 },
                new { Id = 16, Name = "Alone Again", AlbumId = 6 },
                new { Id = 17, Name = "Too Late", AlbumId = 6 },
                new { Id = 18, Name = "Faith", AlbumId = 6 },
                new { Id = 19, Name = "Cry for Me", AlbumId = 7 },
                new { Id = 20, Name = "Timeless", AlbumId = 7 },
                new { Id = 21, Name = "Without a Warning", AlbumId = 7 },
                new { Id = 22, Name = "Gasoline", AlbumId = 8 },
                new { Id = 23, Name = "Sacrifice", AlbumId = 8 },
                new { Id = 24, Name = "Out of Time", AlbumId = 8 },
                new { Id = 25, Name = "9", AlbumId = 9 },
                new { Id = 26, Name = "Hype", AlbumId = 9 },
                new { Id = 27, Name = "With You", AlbumId = 9 },
                new { Id = 28, Name = "Champagne Poetry", AlbumId = 10 },
                new { Id = 29, Name = "Love All", AlbumId = 10 },
                new { Id = 30, Name = "Fair Trade", AlbumId = 10 },
                new { Id = 31, Name = "Nonstop", AlbumId = 11 },
                new { Id = 32, Name = "Elevate", AlbumId = 11 },
                new { Id = 33, Name = "Emotionless", AlbumId = 11 },
                new { Id = 34, Name = "Virginia Beach", AlbumId = 12 },
                new { Id = 35, Name = "Daylight", AlbumId = 12 },
                new { Id = 36, Name = "Slime You Out", AlbumId = 12 },
                new { Id = 37, Name = "Abracadabra", AlbumId = 13 },
                new { Id = 38, Name = "Disease", AlbumId = 13 },
                new { Id = 39, Name = "Garden of Eden", AlbumId = 13 },
                new { Id = 40, Name = "Just Dance", AlbumId = 14 },
                new { Id = 41, Name = "Paparazzi", AlbumId = 14 },
                new { Id = 42, Name = "Poker Face", AlbumId = 14 },
                new { Id = 43, Name = "Venus", AlbumId = 15 },
                new { Id = 44, Name = "G.U.Y.", AlbumId = 15 },
                new { Id = 45, Name = "Applause", AlbumId = 15 },
                new { Id = 46, Name = "Stupid Love", AlbumId = 16 },
                new { Id = 47, Name = "Alice", AlbumId = 16 },
                new { Id = 48, Name = "Enigma", AlbumId = 16 },
                new { Id = 49, Name = "BLACKBIRD", AlbumId = 17 },
                new { Id = 50, Name = "BODYGUARD", AlbumId = 17 },
                new { Id = 51, Name = "DAUGHTER", AlbumId = 17 },
                new { Id = 52, Name = "Hold Up", AlbumId = 18 },
                new { Id = 53, Name = "Sorry", AlbumId = 18 },
                new { Id = 54, Name = "Sandcastles", AlbumId = 18 },
                new { Id = 55, Name = "I Care", AlbumId = 19 },
                new { Id = 56, Name = "1+1", AlbumId = 19 },
                new { Id = 57, Name = "Party", AlbumId = 19 },
                new { Id = 58, Name = "Deja Vu", AlbumId = 20 },
                new { Id = 59, Name = "Ring the Alarm", AlbumId = 20 },
                new { Id = 60, Name = "Green Light", AlbumId = 20 }
            );
        }
        #endregion

        public DbSet<TP2_serveur.Models.Artist> Artist { get; set; } = default!;
        public DbSet<TP2_serveur.Models.Album> Album { get; set; } = default!;
        public DbSet<TP2_serveur.Models.Song> Song { get; set; } = default!;
    }
}
