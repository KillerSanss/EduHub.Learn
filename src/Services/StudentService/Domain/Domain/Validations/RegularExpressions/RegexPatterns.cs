using System.Text.RegularExpressions;

namespace Domain.Validations.RegularExpressions;

/// <summary>
/// Класс для описание регулярных выражений
/// </summary>
public static class RegexPatterns
{
    public static readonly Regex EmailPattern = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    public static readonly Regex PhonePattern = new Regex(@"\+373 [0-9]{8}$");
    public static readonly Regex AvatarUrlPattern = new Regex(@"^https?://.+\.(jpeg|png)$");
    public static readonly Regex LettersPattern = new Regex("\\p{L}'?$");
}

