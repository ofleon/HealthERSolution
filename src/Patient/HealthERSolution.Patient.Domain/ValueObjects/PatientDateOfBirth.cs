namespace HealthERSolution.Patient.Domain.ValueObjects;

public record PatientDateOfBirth
{
    public DateTime Value { get; init; }

    internal PatientDateOfBirth(DateTime value)
    {
        Value = value;
    }

    public static PatientDateOfBirth Create(DateTime value)
    {
        Validate(value);
        return new PatientDateOfBirth(value);
    }

    public static implicit operator DateTime(PatientDateOfBirth petDateOfBirth)
    {
        return petDateOfBirth.Value;
    }

    private static void Validate(DateTime value)
    {
        if (value > DateTime.UtcNow)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Date must not be greater than today");
        }
    }
}
