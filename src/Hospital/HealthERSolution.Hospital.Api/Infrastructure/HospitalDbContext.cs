using HealthERSolution.Hospital.Api.IntegrationEvents;
using Microsoft.EntityFrameworkCore;

namespace HealthERSolution.Hospital.Api.Infrastructure;

public class HospitalDbContext : DbContext
{
    public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
    public DbSet<PatientTransferredToHospitalIntegrationEvent> PatientsMetadata { get; set; }
}
