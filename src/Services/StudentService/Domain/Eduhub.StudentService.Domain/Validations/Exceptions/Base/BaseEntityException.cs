namespace Eduhub.StudentService.Domain.Validations.Exceptions.Core;

/// <summary>
/// Базовове исключение для сущностей
/// </summary>
/// <param name="message">Сообщение об ошибке.</param>
public class BaseEntityException : Exception
{
    protected BaseEntityException(string message) : base(message)
    {
    }
}