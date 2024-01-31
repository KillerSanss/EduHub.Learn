using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.ErrorMessages;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace Eduhub.StudentService.Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации дня рождения
/// </summary>
public static class DateGuard
{
    /// <summary>
    /// Метод для провеки birthDate на значение по умолчанию и на ошибку ввода, когда birthDate больше текущего времени.
    /// </summary>
    public static DateTime Date(this IGuardClause guardClause, DateTime date, [CallerArgumentExpression("date")] string paramName = null)
    {
        Guard.Against.Default(date);

        if (date >= DateTime.Now)
        {
            throw new GuardValidationException(string.Format(ErrorMessage.InvalidData, paramName));
        }

        return date;
    }
}