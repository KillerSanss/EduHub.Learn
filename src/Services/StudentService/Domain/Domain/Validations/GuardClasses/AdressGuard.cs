using Ardalis.GuardClauses;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации адреса
/// </summary>
public static class AdressGuard
{
    /// <summary>
    /// Метод для провекри адреса на null и на соответствие требованиям длины
    /// </summary>
    public static string AdressValidation(this IGuardClause guardClause, string value)
    {
        if (int.TryParse(value, out int result))
        {
            if (result <= 0)
            {
                throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidHouseNumber, nameof(value));
            }
        }
        else if (value != null && (value.Length == 0 || value.Length >= 100))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidAddressLength, nameof(value));
        }

        return value;
    }
}