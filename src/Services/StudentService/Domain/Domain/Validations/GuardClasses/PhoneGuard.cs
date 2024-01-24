using Domain.Validations.RegularExpressions;
using Ardalis.GuardClauses;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации номера телефона
/// </summary>
public static class PhoneGuard
{
    /// <summary>
    /// Метод для провекри phone на null и на соответствие регулярному выражению PhonePattern
    /// </summary>
    public static string PhoneValidation(this IGuardClause guardClause, string phone)
    {
        if (string.IsNullOrWhiteSpace(phone) || !RegexPatterns.PhonePattern.IsMatch(phone))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidPhoneFormat, nameof(phone));
        }

        return phone;
    }
}