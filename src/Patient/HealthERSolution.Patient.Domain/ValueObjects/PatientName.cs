using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthERSolution.Patient.Domain.ValueObjects;

public record PatientName
{
    public string Value { get; init; }

    internal PatientName(string value)
    {
        Value = value;
    }

    public static PatientName Create(string value)
    {
        Validate(value);
        return new PatientName(value);
    }

    public static implicit operator string(PatientName name)
    {
        return name.Value;
    }

    private static void Validate(string value)
    {
        if (value.Length > 50)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Name must not be longer than 50 characters");
        }
    }
}
