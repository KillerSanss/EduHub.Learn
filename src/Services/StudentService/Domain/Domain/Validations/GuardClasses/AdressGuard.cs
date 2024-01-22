using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;
public static class AdressGuard
{
    public static string AdressValidation(this IGuardClause guardClause, string value)
    {
        if (int.TryParse(value, out int result))
        {
            if (result <= 0)
            {
                throw new CustomExceptions.InvalidAddressException(ErrorMessages.ErrorMessages.InvalidHouseNumber, nameof(value));
            }
        }
        else if (value != null && (value.Length == 0 || value.Length >= 100))
        {
            throw new CustomExceptions.InvalidAddressException(ErrorMessages.ErrorMessages.InvalidAddressLength, nameof(value));
        }
        return value;
    }
}