using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;
public static class EmailGuard
{
    public static string EmailValidation(this IGuardClause guardClause, string email)
    {
        if (string.IsNullOrWhiteSpace(email) || !email.Contains('@'))
        {
            throw new CustomExceptions.InvalidEmailException(ErrorMessages.ErrorMessages.InvalidEmailFormat, nameof(email));
        }
        return email;
    }
}