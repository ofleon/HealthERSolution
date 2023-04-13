using HealthERSolution.Hospital.Domain.Entities;
using HealthERSolution.Hospital.Domain.ValueObjects;

namespace HealthERSolution.Hospital.Domain.Repositories;

public interface IPatientAggregateStore
{
    Task SaveAsync(Patient patient);
    Task<Patient> LoadAsync(PatientId patient);
}
