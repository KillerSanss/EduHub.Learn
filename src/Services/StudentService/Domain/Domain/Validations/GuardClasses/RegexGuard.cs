using System.Text.RegularExpressions;
using Domain.Validations.ErrorMessages;
using Domain.Validations.Exceptions;
using Ardalis.GuardClauses;
using System.Runtime.CompilerServices;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации регулярных выражений
/// </summary>
public static class RegexGuard
{
    /// <summary>
    /// Метод для проверки value на соответствие регулярному выражению
    /// </summary>
    public static string Regex(this IGuardClause guardClause, string value, Regex regex, [CallerArgumentExpression("value")] string paramName = null)
    {
        Guard.Against.NullOrEmpty(value);

        if (!regex.IsMatch(value))
        {
            throw new EntityValidationException(string.Format(ErrorMessage.InvalidPattern, paramName));
        }

        return value;
    }
}