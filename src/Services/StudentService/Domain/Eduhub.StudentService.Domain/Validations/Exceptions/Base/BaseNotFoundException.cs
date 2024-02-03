namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовое исключение для не найденых объектов
/// </summary>
public class BaseNotFoundException : Exception
{
    protected BaseNotFoundException(string entityName, string paramName, string value)
        : base(string.Format(ErrorMessage.NotFoundError, entityName, paramName, value))
    {
    }
}