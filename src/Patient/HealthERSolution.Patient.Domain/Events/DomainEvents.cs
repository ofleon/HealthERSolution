using HealthERSolution.Common;

namespace HealthERSolution.Patient.Domain.Events;

public class DomainEvents
{
    public static DomainEvent<PatientTransferredToHospital> PatientTransferredToHospital = new();
}
