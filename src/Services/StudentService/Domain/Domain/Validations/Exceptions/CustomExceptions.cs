namespace Domain.Validations.Exceptions;
public static class CustomExceptions
{
    public class InvalidNameException(string message, string paramName) : ArgumentException(message, paramName);
    public class InvalidGenderException(string message, string paramName) : ArgumentException(message, paramName);
    public class InvalidBirthDateException(string message, string paramName) : ArgumentException(message, paramName);
    public class InvalidEmailException(string message, string paramName) : ArgumentException(message, paramName);
    public class InvalidPhoneFormatException(string message, string paramName) : ArgumentException(message, paramName);
    public class InvalidAddressException(string message, string paramName) : ArgumentException(message, paramName);
    public class InvalidAvatarUrl(string message, string paramName) : ArgumentException(message, paramName);
}