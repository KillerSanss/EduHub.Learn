using Domain.Validations.RegularExpressions;
using Ardalis.GuardClauses;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации ссылки на аватар
/// </summary>
public static class AvatarGuard
{
    /// <summary>
    /// Метод для провеки url на null и на соответсвие регулярному выражению AvatarPattern
    /// </summary>
    public static string AvatarUrlValidation(this IGuardClause guardClause, string url)
    {
        if (string.IsNullOrWhiteSpace(url) || !RegexPatterns.AvatarUrlPattern.IsMatch(url))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidAvatarUrl, nameof(url));
        }

        return url;
    }
}