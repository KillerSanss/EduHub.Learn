namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
public class UpsertCourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; init; }
}

    