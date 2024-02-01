using System.Text.RegularExpressions;

namespace Eduhub.StudentService.Domain.Validations;

/// <summary>
/// Класс для описание регулярных выражений
/// </summary>
public static class RegexPatterns
{
    /// <summary>
    /// Электронная почта
    /// </summary>
    public static readonly Regex EmailPattern = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");

    /// <summary>
    /// Номер телефона
    /// </summary>
    public static readonly Regex PhonePattern = new Regex(@"\+373 [0-9]{8}$");

    /// <summary>
    /// Ссылка на аватар
    /// </summary>
    public static readonly Regex AvatarUrlPattern = new Regex(@"^https?://.+\.(jpeg|png)$");

    /// <summary>
    /// Строки (только буквы)
    /// </summary>
    public static readonly Regex LettersPattern = new Regex("\\p{L}'?$");
}