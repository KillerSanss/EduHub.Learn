using Ardalis.GuardClauses;
using Domain.Validations.RegularExpressions;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации отчества
/// </summary>
public static class LastNameGuard
{
    /// <summary>
    /// Метод для провекри value на null и на соответствие требованиям длины
    /// </summary>
    public static string LastNameValueValidation(this IGuardClause guardClause, string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length <= 2 || value.Length >= 60)
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidLastNameLength, nameof(value));
        }

        // Проверка на соответствие регулярному выражения LettersPattern

        if (!RegexPatterns.LettersPattern.IsMatch(value))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidLastNameCharacters, nameof(value));
        }

        return value;
    }
}