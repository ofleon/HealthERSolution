using HealthERSolution.Patient.Api.Commands;
using HealthERSolution.Patient.Api.IntegrationEvents;
using HealthERSolution.Patient.Domain.Events;
using HealthERSolution.Patient.Domain.Repositories;
using HealthERSolution.Patient.Domain.ValueObjects;

namespace HealthERSolution.Patient.Api.ApplicationServices;

public class PatientApplicationService
{
    private readonly IPatientRepository patientRepository;
    private readonly ILogger<PatientApplicationService> logger;

    public PatientApplicationService(IPatientRepository patientRepository, ILogger<PatientApplicationService> logger)
    {
        this.patientRepository = patientRepository;
        this.logger = logger;

        DomainEvents.PatientTransferredToHospital.Register(async c =>
        {
            var integrationEvent = new PatientTransferredToHospitalIntegrationEvent(c.Id, c.Name, c.Sex, c.DateOfBirth);
        });
    }

    public async Task HandleCommandAsync(CreatePatientCommand command)
    {
        var patient = new Domain.Entities.Patient(PatientId.Create(command.Id));
        patient.SetName(PatientName.Create(command.Name));
        patient.SetSex(SexOfPatient.Create((SexesOfPatients)command.Sex));
        patient.SetDateOfBirth(PatientDateOfBirth.Create(command.DateOfBirth));
        await patientRepository.AddAsync(patient);
    }

    public async Task HandleCommandAsync(SetNameCommand command)
    {
        var patient = await patientRepository.GetAsync(PatientId.Create(command.Id));
        patient.SetName(PatientName.Create(command.Name));
        await patientRepository.UpdateAsync(patient);
    }

    public async Task HandleCommandAsync(SetDateOfBirthCommand command)
    {
        var patient = await patientRepository.GetAsync(PatientId.Create(command.Id));
        patient.SetDateOfBirth(PatientDateOfBirth.Create(command.DateOfBirth));
        await patientRepository.UpdateAsync(patient);
    }

    public async Task HandleCommandAsync(TransferToHospitalCommand command)
    {
        var patient = await patientRepository.GetAsync(PatientId.Create(command.Id));
        patient.TransferToHospital();
    }
}
