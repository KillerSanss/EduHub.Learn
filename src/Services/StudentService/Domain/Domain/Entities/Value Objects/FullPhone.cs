using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;

namespace Domain.Entities.Value_Objects;

/// <summary>
/// Value Object для получения телефона
/// </summary>
public class FullPhone
{
    /// <summary>
    /// Поле описывающее phoneNumber
    /// </summary>
    public string PhoneNumber { get; private set; }

    /// <summary>
    /// Конструктор для устновки значений полей для FullPhone
    /// </summary>
    public FullPhone(string phoneNumber)
    {
        PhoneNumber = Guard.Against.Regex(phoneNumber, RegexPatterns.PhonePattern);
    }
}