namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовое исключение для конфликтов
/// </summary>
public class BaseConflictException : Exception
{
    protected BaseConflictException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessage.ConflictError, entityName, paramName, value))
    {
    }
}