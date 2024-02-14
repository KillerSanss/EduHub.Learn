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
        Surname = ValidateName(surname, nameof(surname));
        FirstName = ValidateName(firstName, nameof(firstName));
        Patronymic = ValidateName(patronymic, nameof(patronymic));
    }

    private static string ValidateName(string value, string paramName)
    {
        Guard.Against.String(value, 2, Operation.GreaterThanOrEqual);
        Guard.Against.String(value, 60, Operation.LessThanOrEqual);
        return Guard.Against.Regex(value, RegexPatterns.LettersPattern, string.Format(ErrorMessage.OnlyLetters, paramName));
    }
}