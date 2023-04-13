namespace HealthERSolution.Patient.Domain.ValueObjects;

public record PatientId
{
    public Guid Value { get; init; }
    internal PatientId(Guid value)
    {
        Value = value;
    }

    public static PatientId Create(Guid value)
    {
        Validate(value);
        return new PatientId(value);
    }

    public static implicit operator Guid(PatientId patientId)
    {
        return patientId.Value;
    }

    private static void Validate(Guid value)
    {
        if (value == Guid.Empty)
        {
            throw new ArgumentException("Id should not be empty", nameof(value));
        }
    }
}
