using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace Eduhub.StudentService.Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации Enum
/// </summary>
public static class EnumGuard
{
    /// <summary>
    /// Метод для провеки Enum на дефолтное значение
    /// </summary>
    public static T Enum<T>(
        this IGuardClause guardClause,
        T value,
        [CallerArgumentExpression("value")] string paramName = null,
        params T[] defaultValues) where T : Enum
    {
        if (defaultValues.Contains(value))
        {
            throw new GuardValidationException(string.Format(ErrorMessage.DefaultEnum, paramName));
        }

        return value;
    }
}