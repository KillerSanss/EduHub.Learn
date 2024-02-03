using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.ErrorMessages;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using Eduhub.StudentService.Domain.Validations.Enums;

namespace Eduhub.StudentService.Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации строк
/// </summary>
public static class StringGuard
{
    /// <summary>
    /// Метод для провеки value на соответствие регулярному выражению
    /// </summary>
    public static string String(this IGuardClause guardClause, string value, int length, Operation operation, [CallerArgumentExpression("value")] string paramName = null)
    {
        Guard.Against.NullOrEmpty(value);

        var isValid = operation switch
        {
            Operation.LessThan => value.Length < length,
            Operation.LessThanOrEqual => value.Length <= length,
            Operation.GreaterThan => value.Length > length,
            Operation.GreaterThanOrEqual => value.Length >= length,
            Operation.Equal => value.Length == length,
            _ => false
        };

        if (!isValid)
        {
            throw new GuardValidationException(string.Format(ErrorMessage.InvalidPattern, paramName));
        }

        return value;
    }
}