namespace HealthERSolution.Patient.Api.Commands;

public record CreatePatientCommand(Guid Id, string Name, int Sex, DateTime DateOfBirth);
public record SetDateOfBirthCommand(Guid Id, DateTime DateOfBirth);
public record SetNameCommand(Guid Id, string Name);
public record TransferToHospitalCommand(Guid Id);
