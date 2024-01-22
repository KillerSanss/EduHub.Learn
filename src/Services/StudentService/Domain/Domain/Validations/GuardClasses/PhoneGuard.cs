using System.Text.RegularExpressions;
using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;

public static class PhoneGuard
{
    private const string PhonePattern = @"\+373[0-9]{8}";

    public static string PhoneValidation(this IGuardClause guardClause, string phone)
    {
        if (string.IsNullOrWhiteSpace(phone) || !Regex.IsMatch(phone, PhonePattern))
        {
            throw new CustomExceptions.InvalidPhoneFormatException(ErrorMessages.ErrorMessages.InvalidPhoneFormat, nameof(phone));
        }

        return phone;
    }
}