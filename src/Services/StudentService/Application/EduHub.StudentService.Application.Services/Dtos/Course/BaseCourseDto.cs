namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Базоваое дто для курса
/// </summary>
public abstract class BaseCourseDto
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; init; }
}