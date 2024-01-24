using Ardalis.GuardClauses;
using Domain.Entities.Enums;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации пола
/// </summary>
public static class GenderGuard
{
    /// <summary>
    /// Метод для провеки gender на соответсвие перечислению Gender
    /// </summary>
    public static Gender GenderValidation(this IGuardClause guardClause, Gender gender)
    {
        if (!Enum.IsDefined(typeof(Gender), gender))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidGender, nameof(gender));
        }

        return gender;
    }
}