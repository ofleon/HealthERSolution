using Microsoft.EntityFrameworkCore;

namespace HealthERSolution.Patient.Api.Infrastructure;

public class PatientDbContext : DbContext
{
    public DbSet<Domain.Entities.Patient> Patients { get; set; }

    public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.Patient>().HasKey(x => x.Id);
        modelBuilder.Entity<Domain.Entities.Patient>().OwnsOne(x => x.Name);
        modelBuilder.Entity<Domain.Entities.Patient>().OwnsOne(x => x.SexOfPatient);
        modelBuilder.Entity<Domain.Entities.Patient>().OwnsOne(x => x.DateOfBirth);
    }
}
