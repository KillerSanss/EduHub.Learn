using Eduhub.StudentService.Domain.Validations.Exceptions.Core;

namespace Eduhub.StudentService.Domain.Validations.Exceptions;

/// <summary>
/// Исключение при ошибки валидации
/// </summary>
/// <param name="message">Сообщение об ошибке.</param>
public class GuardValidationException : BaseEntityException
{
    public GuardValidationException(string message) : base(message)
    {
    }
}