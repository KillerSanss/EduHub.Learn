using Ardalis.GuardClauses;
using Domain.Validations.Exceptions;

namespace Domain.Validations.GuardClasses;
public static class AvatarGuard
{
    public static string AvatarUrlValidation(this IGuardClause guardClause, string url)
    {
        if (string.IsNullOrWhiteSpace(url) || !url.Contains(".jpeg") || !url.Contains(".png"))
        {
            throw new CustomExceptions.InvalidAvatarUrl(ErrorMessages.ErrorMessages.InvalidAvatarUrl, nameof(url));
        }
        return url;
    }
}