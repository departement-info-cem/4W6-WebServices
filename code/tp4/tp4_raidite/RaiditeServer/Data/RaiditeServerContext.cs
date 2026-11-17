using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RaiditeServer.Models;

namespace RaiditeServer.Data
{
    public class RaiditeServerContext(DbContextOptions<RaiditeServerContext> options) : IdentityDbContext<User>(options)
    {
        public DbSet<Hub> Hub { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;
        public DbSet<Picture> Picture { get; set; } = null!;
        public DbSet<Post> Post { get; set; } = null!;
    }
}