using Ardalis.GuardClauses;
using Domain.Validations.GuardClasses;
using Domain.Validations.RegularExpressions;

namespace Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения полного имени
/// </summary>
public class Name
{
    /// <summary>
    /// Фамилия
    /// </summary>
    public string Surname { get; private set; }

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; private set; }

    /// <summary>
    /// Отчество
    /// </summary>
    public string Patronymic { get; private set; }

    /// <summary>
    /// Конструктор для установки значений полей для объекта Name.
    /// </summary>
    /// <param name="surname">Фамилия.</param>
    /// <param name="firstName">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    public Name(string surname, string firstName, string patronymic)
    {
        Surname = Guard.Against.Regex(surname, RegexPatterns.LettersPattern);
        FirstName = Guard.Against.Regex(firstName, RegexPatterns.LettersPattern);
        Patronymic = Guard.Against.Regex(patronymic, RegexPatterns.LettersPattern);
    }
}