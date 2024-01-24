using Domain.Validations.RegularExpressions;
using Ardalis.GuardClauses;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации электронной почты
/// </summary>
public static class EmailGuard
{
    /// <summary>
    /// Метод для провеки email на null и на соответсвие регулярному выражению EmailPattern
    /// </summary>
    public static string EmailValidation(this IGuardClause guardClause, string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !RegexPatterns.EmailPattern.IsMatch(email))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidEmailFormat, nameof(email));
        }

        return email;
    }
}