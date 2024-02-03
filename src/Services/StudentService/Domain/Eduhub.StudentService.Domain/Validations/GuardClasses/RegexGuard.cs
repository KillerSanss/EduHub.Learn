using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace Eduhub.StudentService.Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации регулярных выражений
/// </summary>
public static class RegexGuard
{
    /// <summary>
    /// Метод для проверки value на соответствие регулярному выражению
    /// </summary>
    public static string Regex(
        this IGuardClause guardClause,
        string value,
        Regex regex,
        string message,
        [CallerArgumentExpression("value")] string paramName = null)
    {
        Guard.Against.Null(regex);
        Guard.Against.NullOrEmpty(value);

        if (!regex.IsMatch(value))
        {
            throw new GuardValidationException(string.Format(message, paramName));
        }

        return value;
    }
}