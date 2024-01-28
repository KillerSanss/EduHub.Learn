using Domain.Validations.Exceptions.Core;

namespace Domain.Validations.Exceptions;

/// <summary>
/// Класс для описания кастомного исключения GuardValidationException для ошибок валидации в Guard классах
/// </summary>
public class GuardValidationException : BaseEntityException
{
    public GuardValidationException(string message) : base(message)
    {
    }
}