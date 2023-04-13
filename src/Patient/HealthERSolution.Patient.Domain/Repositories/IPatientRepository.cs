using HealthERSolution.Patient.Domain.ValueObjects;

namespace HealthERSolution.Patient.Domain.Repositories;

public interface IPatientRepository
{
    Task<Entities.Patient> GetAsync(PatientId id);
    Task AddAsync(Entities.Patient pet);
    Task UpdateAsync(Entities.Patient pet);
}
