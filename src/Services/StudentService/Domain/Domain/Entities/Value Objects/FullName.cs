using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;

namespace Domain.Entities.Value_Objects;

/// <summary>
/// Value Object для получения полного имени
/// </summary>
public class FullName
{
    /// <summary>
    /// Поле описывающее surname
    /// </summary>
    public string Surname { get; private set; }

    /// <summary>
    /// Поле описывающее firstname
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Поле описывающее patronymic
    /// </summary>
    public string Patronymic { get; private set; }

    /// <summary>
    /// Конструктор для устновки значений полей для FullName
    /// </summary>
    public FullName(string surname, string firstName, string patronymic)
    {
        Surname = Guard.Against.Regex(surname, RegexPatterns.LettersPattern);
        FirstName = Guard.Against.Regex(firstName, RegexPatterns.LettersPattern);
        Patronymic = Guard.Against.Regex(patronymic, RegexPatterns.LettersPattern);
    }
}