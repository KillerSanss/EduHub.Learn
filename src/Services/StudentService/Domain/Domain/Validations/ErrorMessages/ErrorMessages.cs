namespace Domain.Validations.ErrorMessages;
public static class ErrorMessages
{
    public const string InvalidNameLength = "ФИО введено некорректно";
    public const string InvalidNameCharacters = "В ФИО могут быть только буквы";
    public const string InvalidGender = "Введен неверный пол";
    public const string InvalidBirthDate = "Дата рождения не может быть в будущем";
    public const string InvalidEmailFormat = "Некорректный формат электронной почты";
    public const string InvalidPhoneFormat = "Некорректный формат телефона";
    public const string InvalidHouseNumber = "Номер дома не может быть отрицательным";
    public const string InvalidAddressLength = "Название введено некорректно";
    public const string InvalidAvatarUrl = "Указана неверная ссылка на изображение";
}