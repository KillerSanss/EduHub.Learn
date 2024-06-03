using System.Text.RegularExpressions;

namespace Eduhub.StudentService.Domain.Validations;

/// <summary>
/// Класс для описания регулярных выражений
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    public static readonly Regex EmailPattern = new (@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}");

    /// <summary>
    /// Номер телефона
    /// </summary>
    public static readonly Regex PhonePattern = new (@"^373\d{8}$");

    /// <summary>
    /// Ссылка на аватар
    /// </summary>
    public static readonly Regex AvatarUrlPattern = new (@"^https?://.+\.(jpeg|png)$");

    /// <summary>
    /// Строки (только буквы)
    /// </summary>
    public static readonly Regex LettersPattern = new ("\\p{L}'?$");
}