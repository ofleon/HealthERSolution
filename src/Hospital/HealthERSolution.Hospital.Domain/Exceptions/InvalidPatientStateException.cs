namespace HealthERSolution.Hospital.Domain.Exceptions;

public class InvalidPatientStateException : Exception
{
    public InvalidPatientStateException(string message) : base(message)
    {
    }
}
