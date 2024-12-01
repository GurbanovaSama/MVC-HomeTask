using Microsoft.EntityFrameworkCore;
using SimulationExamProject.Models;

namespace SimulationExamProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Master> Masters { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; } 
        

    }
}
