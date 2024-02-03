namespace Eduhub.StudentService.Domain.Validations.ErrorMessages;

/// <summary>
/// Класс для хранения сообщений об исключениях при валидации
/// </summary>
public static class ErrorMessage
{
    public const string InvalidData = "{0} is incorrect";
    public const string InvalidPattern = "{0} has a wrong format";
    public const string ConflictError = "Entity {0} with {1} = {2} is already exist";
    public const string NotFoundError = "Entity {0} with {1} = {2} not found.";
}