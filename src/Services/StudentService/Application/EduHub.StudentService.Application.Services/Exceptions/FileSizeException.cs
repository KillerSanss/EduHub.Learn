namespace EduHub.StudentService.Application.Services.Exceptions;

/// <summary>
/// Исключение большого размера файла
/// </summary>
public class FileSizeException : Exception
{
    public FileSizeException(string message) : base(message)
    {
    }
}