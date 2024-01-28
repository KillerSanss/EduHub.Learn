using Domain.Validations.ErrorMessages;
using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;
using System.Runtime.CompilerServices;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации Enum
/// </summary>
public static class EnumGuard
{
    /// <summary>
    /// Метод для провеки Enum на дефолтное значение
    /// </summary>
    public static T Enum<T>(this IGuardClause guardClause, T value, [CallerArgumentExpression("value")] string paramName = null) where T : Enum
    {
        if (EqualityComparer<T>.Default.Equals(value, default))
        {
            throw new GuardValidationException(string.Format(ErrorMessage.InvalidData, paramName));
        }

        return value;
    }
}