namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Файл настроек для MinIo
/// </summary>
public class MinioSettings
{
    /// <summary>
    /// Название бакета
    /// </summary>
    public string BucketName { get; init; }
    
    /// <summary>
    /// Конечная точка
    /// </summary>
    public string EndPoint { get; init; }
    
    /// <summary>
    /// Ключ доступа
    /// </summary>
    public string AccessKey { get; init; }
    
    /// <summary>
    /// Секретный ключ
    /// </summary>
    public string SecretKey { get; init; }
}