using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;

namespace Domain.Entities.Value_Objects;

/// <summary>
/// Value Object для получения Email
/// </summary>
public class FullEmail
{
    /// <summary>
    /// Поле описывающее email
    /// </summary>
    public string Email { get; private set; }

    /// <summary>
    /// Конструктор для устновки значений полей для FullEmail
    /// </summary>
    public FullEmail(string email)
    {
        Email = Guard.Against.Regex(email, RegexPatterns.EmailPattern);
    }
}