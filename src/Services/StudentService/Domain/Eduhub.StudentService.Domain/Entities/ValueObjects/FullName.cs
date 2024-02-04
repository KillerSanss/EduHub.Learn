using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using Eduhub.StudentService.Domain.Validations.Enums;

namespace Eduhub.StudentService.Domain.Entities.ValueObjects;

/// <summary>
/// Value Object для получения полного имени
/// </summary>
public class FullName
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
    public FullName(string surname, string firstName, string patronymic)
    {
        Common(surname, firstName, patronymic);
    }

    private void Common(string surname, string firstName, string patronymic)
    {
        Guard.Against.String(surname, 2, Operation.GreaterThanOrEqual);
        Guard.Against.String(surname, 60, Operation.LessThanOrEqual);
        Surname = Guard.Against.Regex(surname, RegexPatterns.LettersPattern, string.Format(ErrorMessage.OnlyLetters, nameof(surname)));
        Guard.Against.String(firstName, 2, Operation.GreaterThanOrEqual);
        Guard.Against.String(firstName, 60, Operation.LessThanOrEqual);
        FirstName = Guard.Against.Regex(firstName, RegexPatterns.LettersPattern, string.Format(ErrorMessage.OnlyLetters, nameof(firstName)));
        Guard.Against.String(patronymic, 2, Operation.GreaterThanOrEqual);
        Guard.Against.String(patronymic, 60, Operation.LessThanOrEqual);
        Patronymic = Guard.Against.Regex(patronymic, RegexPatterns.LettersPattern, string.Format(ErrorMessage.OnlyLetters, nameof(patronymic)));
    }
}