using Eduhub.StudentService.Domain.Validations.Exceptions.Base;

namespace Eduhub.StudentService.Domain.Validations.Exceptions;

/// <summary>
/// Исключение при ошибки валидации
/// </summary>
public class GuardValidationException : BaseEntityException
{
    public GuardValidationException(string message) : base(message)
    {
    }
}