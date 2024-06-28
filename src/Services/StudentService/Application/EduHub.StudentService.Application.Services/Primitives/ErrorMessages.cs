namespace EduHub.StudentService.Application.Services.Primitives;

/// <summary>
/// Класс для хранения сообщений об исключениях при валидации
/// </summary>
public static class ErrorMessages
{
    /// <summary>
    /// Сообщение о некорректности введенных данных
    /// </summary>
    public const string InvalidData = "'{PropertyName}' is incorrect";

    /// <summary>
    /// Сообщение об ошибке формата - только буквы
    /// </summary>
    public const string OnlyLetters = "'{PropertyName}' must contains only letters and symbols";

    /// <summary>
    /// Сообщение об ошибке перечисления
    /// </summary>
    public const string DefaultEnum = "Enum '{PropertyName}' cannot be default";

    /// <summary>
    /// Сообщение об ошибке формата - недействительная длина
    /// </summary>
    public const string InvalidLength = "'{PropertyName}' must be correct length";

    /// <summary>
    /// Сообщение об ошибке даты
    /// </summary>
    public const string FutureDate = "'{PropertyName}' cannot be in future";

    /// <summary>
    /// Сообщение об ошибке некорректного формата электронной почты
    /// </summary>
    public const string EmailFormat = "Email must be correct format. Example: abc@gmail.com.";

    /// <summary>
    /// Сообщение об ошибке некорректного формата номера телефона
    /// </summary>
    public const string PhoneFormat = "Phone must be correct format. Example: 37377899999";

    /// <summary>
    /// Сообщение об ошибке некорректного формата ссылки на аватар
    /// </summary>
    public const string AvatarPattern = "Avatar url must be correct format.";

    /// <summary>
    /// Сообщение об ошибке конфликта
    /// </summary>
    /// <remarks>
    /// Использовать вместе со string.Format
    /// {0} - имя сущности
    /// {1} - имя свойства
    /// </remarks>
    public const string ConflictError = "Entity {0} with similar {1} is already exist";

    /// <summary>
    /// Сообщение об ошибке не найденной сущности
    /// </summary>
    /// <remarks>
    /// Использовать вместе со string.Format
    /// {0} - имя сущности
    /// {1} - имя свойства
    /// {2} - значение свойства
    /// </remarks>
    public const string NotFoundError = "Entity {0} with {1} = {2} is not found.";
}
