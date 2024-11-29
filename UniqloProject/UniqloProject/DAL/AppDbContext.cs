using Microsoft.EntityFrameworkCore;
using UniqloProject.Models;

namespace UniqloProject.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<SliderItem> SliderItems { get; set; }
    }
}
