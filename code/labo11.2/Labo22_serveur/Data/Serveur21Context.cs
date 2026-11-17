using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using serveur21.Models;

namespace serveur21.Data
{
    public class Serveur21Context(DbContextOptions<Serveur21Context> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Review> Review { get; set; } = null!;
    }
}