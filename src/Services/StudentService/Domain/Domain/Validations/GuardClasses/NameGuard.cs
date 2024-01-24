using Ardalis.GuardClauses;
using Domain.Validations.RegularExpressions;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации имени
/// </summary>
public static class NameGuard
{
    /// <summary>
    /// Метод для провекри value на null и на соответствие требованиям длины
    /// </summary>
    public static string NameValueValidation(this IGuardClause guardClause, string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length <= 2 || value.Length >= 60)
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidNameLength, nameof(value));
        }

        // Проверка на соответствие регулярному выражения LettersPattern

        if (!RegexPatterns.LettersPattern.IsMatch(value))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidNameCharacters, nameof(value));
        }

        return value;
    }
}