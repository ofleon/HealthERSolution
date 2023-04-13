using HealthERSolution.Common;

namespace HealthERSolution.Hospital.Domain.Events;

public record PatientWeightUpdated(Guid Id, decimal Value) : IDomainEvent { }
