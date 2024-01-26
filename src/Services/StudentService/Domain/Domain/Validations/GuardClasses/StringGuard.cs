using Domain.Validations.ErrorMessages;
using Domain.Validations.Exceptions;
using Ardalis.GuardClauses;
using System.Runtime.CompilerServices;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации строк
/// </summary>
public static class StringGuard
{
    /// <summary>
    /// Метод для провеки value на соответствие регулярному выражению
    /// </summary>
    public static string String(this IGuardClause guardClause, string value, [CallerArgumentExpression("value")] string paramName = null)
    {
        Guard.Against.NullOrEmpty(value);

        if (value.Length <= 2 || value.Length >= 100)
        {
            throw new EntityValidationException(string.Format(ErrorMessage.InvalidPattern, paramName));
        }

        return value;
    }
}