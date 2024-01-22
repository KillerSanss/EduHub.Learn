using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;
public static class StringValueValidation
{
    public static string StringValidation(this IGuardClause guardClause, string value)
    {
        if (string.IsNullOrWhiteSpace(value) || value.Length <= 2 || value.Length >= 60)
        {
            throw new CustomExceptions.InvalidNameException(ErrorMessages.ErrorMessages.InvalidNameLength, nameof(value));
        }
        foreach (char c in value)
        {
            if (!char.IsLetter(c))
            {
                throw new CustomExceptions.InvalidNameException(ErrorMessages.ErrorMessages.InvalidNameCharacters, nameof(value));
            }
        }
        return value;
    }
}