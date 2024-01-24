using Ardalis.GuardClauses;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации дня рождения
/// </summary>
public static class BirthGuard
{
    /// <summary>
    /// Метод для провеки birthDate на значение по умолчанию и на ошибку ввода, когда birthDate больше текущего времени.
    /// </summary>
    public static DateTime BirthValidation(this IGuardClause guardClause, DateTime bitrhDate)
    {
        if (bitrhDate == DateTime.MinValue || bitrhDate >= DateTime.Now)
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidBirthDate, nameof(bitrhDate));
        }

        return bitrhDate;
    }
}