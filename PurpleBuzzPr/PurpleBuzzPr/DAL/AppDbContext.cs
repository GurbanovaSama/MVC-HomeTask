using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PurpleBuzzPr.Models;

namespace PurpleBuzzPr.DAL
{
    public class AppDbContext: IdentityDbContext<AppUser>
    {
       
        public AppDbContext(DbContextOptions options): base(options) { }
        
        public DbSet<Work> Works { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Work>()
                .HasOne(e => e.Service)
                .WithMany(e => e.Works)
                .HasForeignKey(e => e.ServiceId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
