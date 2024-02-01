using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.ErrorMessages;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using Eduhub.StudentService.Domain.Entities.Enums;

namespace Eduhub.StudentService.Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации строк
/// </summary>
public static class StringGuard
{
    /// <summary>
    /// Метод для провеки value на соответствие регулярному выражению
    /// </summary>
    public static string String(this IGuardClause guardClause, string value, int lenght, Operation operation, [CallerArgumentExpression("value")] string paramName = null)
    {
        Guard.Against.NullOrEmpty(value);
        Guard.Against.Enum(operation, defaultValues: Operation.None);

        bool isValid = false;

        switch (operation)
        {
            case Operation.LessThan:
                isValid = value.Length < lenght;
                break;
            case Operation.LessThanOrEqual:
                isValid = value.Length <= lenght;
                break;
            case Operation.GreaterThan:
                isValid = value.Length > lenght;
                break;
            case Operation.GreaterThanOrEqual:
                isValid = value.Length >= lenght;
                break;
            case Operation.Equal:
                isValid = value.Length == lenght;
                break;
        }

        if (!isValid)
        {
            throw new GuardValidationException(string.Format(ErrorMessage.InvalidPattern, paramName));
        }

        return value;
    }
}