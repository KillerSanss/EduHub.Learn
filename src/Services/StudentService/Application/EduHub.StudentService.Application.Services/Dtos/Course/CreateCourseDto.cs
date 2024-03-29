namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
public record CreateCourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="name">Название курса.</param>
    /// <param name="description">Описание.</param>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    public CreateCourseDto(string name, string description, Guid educatorId) : base(name, description)
    {
        EducatorId = educatorId;
    }
}
    