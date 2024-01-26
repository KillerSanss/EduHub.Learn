namespace Domain.Validations.ErrorMessages;

/// <summary>
/// Класс для хранения сообщений об исключениях при валидации
/// </summary>
public static class ErrorMessage
{
    public const string InvalidData = "{0} введен не правельно";
    public const string NegativeError = "{0} не может быть отрацательным";

    public const string InvalidPattern = "{0} имеет неверный формат написания";

    public const string NotNullError = "{0} is not Null";
    public const string NullError = "{0} is Null";

}
