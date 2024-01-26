using Domain.Validations.ErrorMessages;
using Ardalis.GuardClauses;
using Domain.Entities.Enums;
using Domain.Validations.Exceptions;
using System.Runtime.CompilerServices;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации пола
/// </summary>
public static class GenderGuard
{
    /// <summary>
    /// Метод для провеки gender на соответсвие перечислению Gender
    /// </summary>
    public static Gender Gender(this IGuardClause guardClause, Gender gender, [CallerArgumentExpression("gender")] string paramName = null)
    {
        if (gender == Entities.Enums.Gender.None)
        {
            throw new EntityValidationException(string.Format(ErrorMessage.InvalidData, paramName));
        }

        return gender;
    }
}