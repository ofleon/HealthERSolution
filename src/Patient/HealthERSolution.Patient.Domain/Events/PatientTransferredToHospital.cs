using HealthERSolution.Common;

namespace HealthERSolution.Patient.Domain.Events;

public record PatientTransferredToHospital(Guid Id, string Name, int Sex, DateTime DateOfBirth) : IDomainEvent { }
