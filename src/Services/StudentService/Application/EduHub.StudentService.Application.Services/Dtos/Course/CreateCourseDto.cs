namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
public class CreateCourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; init; }
}

    