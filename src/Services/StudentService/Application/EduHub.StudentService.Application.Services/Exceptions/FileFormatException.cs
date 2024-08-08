namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Исключение неверного формата файла
/// </summary>
public class FileFormatException : Exception
{
    public FileFormatException(string message) : base(message)
    {
    }
}