namespace HealthERSolution.Patient.Domain.ValueObjects;

public record SexOfPatient
{
    public SexesOfPatients Value { get; init; }
    internal SexOfPatient(SexesOfPatients value)
    {
        Value = value;
    }

    public static SexOfPatient Create(SexesOfPatients value)
    {
        return new SexOfPatient(value);
    }

    public static implicit operator int(SexOfPatient value)
    {
        return (int)value.Value;
    }

    public static SexOfPatient Male = new SexOfPatient(SexesOfPatients.Male);
    public static SexOfPatient Female = new SexOfPatient(SexesOfPatients.Female);
}

public enum SexesOfPatients
{
    Male,
    Female
}