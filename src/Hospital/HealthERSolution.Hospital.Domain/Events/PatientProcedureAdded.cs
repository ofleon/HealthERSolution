using HealthERSolution.Common;

namespace HealthERSolution.Hospital.Domain.Events;

public record PatientProcedureAdded(Guid PatientId, Guid Id, string ProcedureName) : IDomainEvent { }
