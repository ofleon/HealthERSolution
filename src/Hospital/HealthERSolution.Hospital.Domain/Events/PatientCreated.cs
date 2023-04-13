using HealthERSolution.Common;

namespace HealthERSolution.Hospital.Domain.Events;

public record PatientCreated(Guid Id) : IDomainEvent { }
