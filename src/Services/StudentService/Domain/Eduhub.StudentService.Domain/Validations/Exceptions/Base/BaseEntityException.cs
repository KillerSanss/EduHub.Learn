namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовове исключение для сущностей
/// </summary>
public class BaseEntityException : Exception
{
    protected BaseEntityException(string message) : base(message)
    {
    }
}