namespace BikeRent.Application.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(IEnumerable<ValidationError> errors)
    {
        Errors = errors;
    }

    public IEnumerable<ValidationError> Errors { get; }
}
