using Ardalis.GuardClauses;
using Domain.Entities.Enums;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;
public static class GenderGuard
{
    public static Genders GenderValidation(this IGuardClause guardClause, Genders gender)
    {
        if (gender != Genders.Male && gender != Genders.Female)
        {
            throw new CustomExceptions.InvalidGenderException(ErrorMessages.ErrorMessages.InvalidGender, nameof(gender));
        }

        return gender;
    }
}