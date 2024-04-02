namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
public class CourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Идентифакатор преподавателя
    /// </summary>
    public Guid EducatorId { get; init; }
}