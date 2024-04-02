using Eduhub.StudentService.Domain.Validations.Exceptions.Base;

namespace Eduhub.StudentService.Domain.Validations.Exceptions;

/// <summary>
/// Исключение при ошибки валидации
/// </summary>
public class GuardValidationException : BaseEntityException
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public GuardValidationException(string message) : base(message)
    {
    }
}