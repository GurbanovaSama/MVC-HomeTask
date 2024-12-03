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
        public DbSet<Category> Categories { get; set; } 
        public DbSet<Product> Products { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(x=> x.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);
        }


    }
}
