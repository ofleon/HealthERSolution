using HealthERSolution.Common;

namespace HealthERSolution.Hospital.Domain.Events;

public record PatientDischarged(Guid Id) : IDomainEvent { }
