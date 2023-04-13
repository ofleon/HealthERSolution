namespace HealthERSolution.Hospital.Api.IntegrationEvents;

public record PatientTransferredToHospitalIntegrationEvent(Guid Id, string Name, int Sex, DateTime DateOfBirth);
