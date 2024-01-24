using Ardalis.GuardClauses;

namespace Domain.Validations.GuardClasses;

/// <summary>
/// Гуард для валидации описания
/// </summary>
public static class DescriptionGuard
{
    /// <summary>
    /// Метод для провеки value на null
    /// </summary>
    public static string DescriptionValidation(this IGuardClause guardClause, string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new Exceptions.InvalidDataException(ErrorMessages.ErrorMessages.InvalidNameLength, nameof(value));
        }

        return value;
    }
}