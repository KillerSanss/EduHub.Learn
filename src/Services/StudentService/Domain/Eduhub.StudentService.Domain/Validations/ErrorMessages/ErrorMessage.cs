namespace Eduhub.StudentService.Domain.Validations.ErrorMessages;

/// <summary>
/// Класс для хранения сообщений об исключениях при валидации
/// </summary>
public static class ErrorMessage
{
    public const string InvalidData = "{0} is incorrect";
    public const string InvalidPattern = "{0} has a wrong format";
    public const string ConflictError = "{0} is already exist";
    public const string NotFoundError = "{0} not found.";
}