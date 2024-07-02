using System.Collections;

namespace EduHub.StudentService.Api.Middleware.Models;

/// <summary>
/// Класс для ошибки
/// </summary>
public class ExceptionResponse
{
    /// <summary>
    /// Тип ошибки
    /// </summary>
    public string Type { get; set; }
    
    /// <summary>
    /// Сообщение
    /// </summary>
    public string Message { get; set; }
    
    /// <summary>
    /// Stack trace
    /// </summary>
    public string StackTrace { get; set; }
    
    /// <summary>
    /// Информация
    /// </summary>
    public IDictionary Data { get; set; }
}