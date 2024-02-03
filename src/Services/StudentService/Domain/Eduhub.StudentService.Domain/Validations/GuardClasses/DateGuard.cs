using System.Runtime.CompilerServices;
using Ardalis.GuardClauses;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace Eduhub.StudentService.Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации даты
/// </summary>
public static class DateGuard
{
    /// <summary>
    /// Метод для проверки даты, не превышающая текущую дату
    /// </summary>
    public static DateTime FutureDate(
        this IGuardClause guardClause,
        DateTime date,
        [CallerArgumentExpression("date")] string paramName = null)
    {
        Guard.Against.Default(date);

        if (date > DateTime.Now)
        {
            throw new GuardValidationException(string.Format(ErrorMessage.InvalidData, paramName));
        }

        return date;
    }
}