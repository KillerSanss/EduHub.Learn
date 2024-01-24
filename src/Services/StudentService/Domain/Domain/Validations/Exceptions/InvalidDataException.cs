namespace Domain.Validations.Exceptions;

/// <summary>
/// Класс для описания кастомного исключения InvalidDataException для ошибок ввода данных
/// </summary>
public class InvalidDataException : ArgumentException
{
    public InvalidDataException(string message, string paramName) : base(message, paramName)
    {
    }
}