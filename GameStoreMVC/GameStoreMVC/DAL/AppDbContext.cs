using GameStoreMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStoreMVC.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Game> Games { get; set; }

    }
}
