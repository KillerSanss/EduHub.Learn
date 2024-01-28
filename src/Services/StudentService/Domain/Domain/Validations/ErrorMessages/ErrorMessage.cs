namespace Domain.Validations.ErrorMessages;

/// <summary>
/// Класс для хранения сообщений об исключениях при валидации
/// </summary>
public static class ErrorMessage
{
    public const string InvalidData = "{0} is incorrect";
    public const string InvalidPattern = "{0} has a wrong format";
    public const string NotNullError = "{0} is not Null";
    public const string NullError = "{0} is Null";
}