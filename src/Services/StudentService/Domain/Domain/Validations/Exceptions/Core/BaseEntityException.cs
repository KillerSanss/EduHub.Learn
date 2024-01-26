namespace Domain.Validations.Exceptions.Core;

public class BaseEntityException : Exception
{
    protected BaseEntityException(string message) : base(message)
    {
    }
}