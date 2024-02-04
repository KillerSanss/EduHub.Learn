using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations;
using Eduhub.StudentService.Domain.Validations.Enums;

namespace Eduhub.StudentService.Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения Email
/// </summary>
public class Email
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Email.
    /// </summary>
    /// <param name="email">Электронная почта.</param>
    public Email(string email)
    {
        Guard.Against.String(email, 255, Operation.LessThanOrEqual);
        Value = Guard.Against.Regex(email, RegexPatterns.EmailPattern, ErrorMessage.EmailFormat);
    }
}