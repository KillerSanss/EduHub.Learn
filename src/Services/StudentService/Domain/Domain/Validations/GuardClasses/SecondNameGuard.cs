using Ardalis.GuardClauses;
using Domain.Validations.RegularExpressions;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации фамилии
/// </summary>
public static class SecondNameGuard
{
    /// <summary>
    /// Метод для провекри value на null и на соответствие требованиям длины
    /// </summary>
    public static string SecondNameValueValidation(this IGuardClause guardClause, string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length <= 2 || value.Length >= 60)
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidSecondNameLength, nameof(value));
        }

        // Проверка на соответствие регулярному выражения LettersPattern

        if (!RegexPatterns.LettersPattern.IsMatch(value))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidSecondNameCharacters, nameof(value));
        }

        return value;
    }
}