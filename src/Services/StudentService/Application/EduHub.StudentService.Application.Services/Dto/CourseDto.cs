namespace EduHub.StudentService.Application.Services.Dto;

/// <summary>
/// Dto класс для курса
/// </summary>
public class CourseDto
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Описание курса
    /// </summary>
    public string Description { get; init; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; init; }
}