using System.Globalization;
using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;
public static class BirthGuard
{
    public static DateTime BirthValidation(this IGuardClause guardClause, DateTime bitrhDate)
    {
        if (string.IsNullOrEmpty(bitrhDate.ToString(CultureInfo.CurrentCulture)) || bitrhDate >= DateTime.Now)
        {
            throw new CustomExceptions.InvalidBirthDateException(ErrorMessages.ErrorMessages.InvalidBirthDate, nameof(bitrhDate));
        }
        return bitrhDate;
    }
}