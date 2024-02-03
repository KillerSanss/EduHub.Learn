using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations;

namespace Eduhub.StudentService.Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения телефона
/// </summary>
public class Phone
{
    /// <summary>
    /// Номер телефона
    /// </summary>
    public string Value { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Phone.
    /// </summary>
    /// <param name="phoneNumber">Номер телефона.</param>
    public Phone(string phoneNumber)
    {
        Value = Guard.Against.Regex(phoneNumber, RegexPatterns.PhonePattern, ErrorMessage.PhoneFormat);
    }
}