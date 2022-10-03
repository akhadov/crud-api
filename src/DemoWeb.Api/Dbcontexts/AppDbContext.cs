using DemoWeb.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoWeb.Api.Dbcontexts
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; } = null!;
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(p => p.Email).IsUnique();
            modelBuilder.Entity<User>().HasIndex(p => p.PhoneNumber).IsUnique();
        }
    }
}
