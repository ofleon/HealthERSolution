using HealthERSolution.Patient.Domain.Events;
using HealthERSolution.Patient.Domain.Exceptions;
using HealthERSolution.Patient.Domain.ValueObjects;

namespace HealthERSolution.Patient.Domain.Entities;

public class Patient
{
    public Guid Id { get; init; }
    public PatientName Name { get; private set; }
    public SexOfPatient SexOfPatient { get; private set; }
    public PatientDateOfBirth DateOfBirth { get; private set; }

    public Patient(PatientId id)
    {
        Id = id;
    }
    public Patient()
    {

    }
    public void SetName(PatientName name)
    {
        Name = name;
    }

    public void SetSex(SexOfPatient sex)
    {
        SexOfPatient = sex;
    }

    public void SetDateOfBirth(PatientDateOfBirth dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
    }

    public void TransferToHospital()
    {
        ValidateStateForTransfer();
        DomainEvents.PatientTransferredToHospital.Publish(new PatientTransferredToHospital(Id, Name, SexOfPatient, DateOfBirth));
    }

    private void ValidateStateForTransfer()
    {
        if (Name == null)
        {
            throw new InvalidPatientStateException("Name is missing");
        }
        if (SexOfPatient == null)
        {
            throw new InvalidPatientStateException("Sex of patient is missing");
        }
        if (DateOfBirth == null)
        {
            throw new InvalidPatientStateException("Date of birth is missing");
        }
    }
}
