namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто курса
/// </summary>
public class EducatorCourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }
}