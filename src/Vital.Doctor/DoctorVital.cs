using Microsoft.EntityFrameworkCore;

namespace Vital.Doctor
{
    public class DoctorVital : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=VitalDoctor;Trusted_Connection=True;");
        }

        public virtual DbSet<DoctorMedicalConcept> DoctorMedicalConcepts { get; set; }
        public virtual DbSet<DoctorMedicalConceptResources> DoctorMedicalConceptResources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DoctorMedicalConcept>()
                .HasMany(d => d.Resources)
                .WithOne();
        }
    }
}
