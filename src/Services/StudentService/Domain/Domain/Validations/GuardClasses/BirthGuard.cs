using Domain.Validations.ErrorMessages;
using Domain.Validations.Exceptions;
using Ardalis.GuardClauses;
using System.Runtime.CompilerServices;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации дня рождения
/// </summary>
public static class BirthGuard
{
    /// <summary>
    /// Метод для провеки birthDate на значение по умолчанию и на ошибку ввода, когда birthDate больше текущего времени.
    /// </summary>
    public static DateTime BirthValidation(this IGuardClause guardClause, DateTime birthDate, [CallerArgumentExpression("birthDate")] string paramName = null)
    {
        Guard.Against.Default(birthDate);

        if (birthDate >= DateTime.Now)
        {
            throw new EntityValidationException(string.Format(ErrorMessage.InvalidData, paramName));
        }

        return birthDate;
    }
}