using HealthERSolution.Patient.Domain.Repositories;
using HealthERSolution.Patient.Domain.ValueObjects;

namespace HealthERSolution.Patient.Api.Infrastructure;

public class PatientRepository : IPatientRepository
{
    private readonly PatientDbContext patientDbContext;

    public PatientRepository(PatientDbContext patientDbContext)
    {
        this.patientDbContext = patientDbContext;
    }
    public async Task<Domain.Entities.Patient> GetAsync(PatientId id)
    {
        return await patientDbContext.Patients.FindAsync((Guid)id);
    }

    public async Task AddAsync(Domain.Entities.Patient patient)
    {
        patientDbContext.Patients.Add(patient);
        await patientDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Domain.Entities.Patient pet)
    {
        patientDbContext.Patients.Update(pet);
        await patientDbContext.SaveChangesAsync();
    }
}
