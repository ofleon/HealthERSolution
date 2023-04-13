using HealthERSolution.Common;

namespace HealthERSolution.Hospital.Domain.Events;

public record PatientBloodTypeUpdated(Guid Id, string BloodType) : IDomainEvent { }
