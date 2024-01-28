namespace Domain.Validations.Exceptions.Core;

/// <summary>
/// Класс для описания кастомных исключений, которые будут наследовать этот класс
/// </summary>
public class BaseEntityException : Exception
{
    protected BaseEntityException(string message) : base(message)
    {
    }
}