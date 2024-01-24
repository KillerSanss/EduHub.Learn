namespace Domain.Validations.ErrorMessages;

/// <summary>
/// Класс для хранения сообщений об исключениях при валидации
/// </summary>
public static class ErrorMessages
{
    public const string InvalidNameLength = "Имя введено некорректно";
    public const string InvalidSecondNameLength = "Фамилия введена некорректно";
    public const string InvalidLastNameLength = "Отчество введено некорректно";
    public const string InvalidNameCharacters = "В имени могут быть только буквы";
    public const string InvalidSecondNameCharacters = "В фамилии могут быть только буквы";
    public const string InvalidLastNameCharacters = "В отчестве могут быть только буквы";
    public const string InvalidGender = "Введен неверный пол";
    public const string InvalidBirthDate = "Дата рождения не может быть в будущем";
    public const string InvalidEmailFormat = "Некорректный формат электронной почты";
    public const string InvalidPhoneFormat = "Некорректный формат телефона";
    public const string InvalidHouseNumber = "Номер дома не может быть отрицательным";
    public const string InvalidAddressLength = "Название введено некорректно";
    public const string InvalidAvatarUrl = "Указана неверная ссылка на изображение";
}