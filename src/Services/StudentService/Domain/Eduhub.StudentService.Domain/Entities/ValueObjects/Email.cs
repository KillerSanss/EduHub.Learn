using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations.RegularExpressions;

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
        Value = Guard.Against.Regex(email, RegexPatterns.EmailPattern);
    }
}