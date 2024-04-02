namespace Eduhub.StudentService.Domain.Validations.Exceptions.Base;

/// <summary>
/// Базовове исключение для сущностей
/// </summary>
public abstract class BaseEntityException : Exception
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    protected BaseEntityException(string message) : base(message)
    {
    }
}