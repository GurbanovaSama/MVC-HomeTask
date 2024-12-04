using HospitalTask.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalTask.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<HospitalDoctor> HospitalDoctors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One to Many
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId);



            //Many to Many 
            modelBuilder.Entity<HospitalDoctor>()
            .HasOne(w => w.Doctor)
            .WithMany(e => e.HospitalDoctors)   
            .HasForeignKey(w => w.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<HospitalDoctor>()
            .HasOne(w => w.Hospital)
            .WithMany(e => e.HospitalDoctors)
            .HasForeignKey(w => w.HospitalId)
            .OnDelete(DeleteBehavior.Restrict);
        }

        
       
    }
}
