using HealthERSolution.Common;

namespace HealthERSolution.Hospital.Domain.Events;

public record PatientAdmitted(Guid Id) : IDomainEvent { }
