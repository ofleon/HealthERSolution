using HealthERSolution.Common;

namespace HealthERSolution.Patient.Api.IntegrationEvents;
public record PatientTransferredToHospitalIntegrationEvent(Guid Id, string Name, int Sex, DateTime DateOfBirth) : IIntegrationEvent { }
