namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
public record UpdateCourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid EducatorId { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="name">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    public UpdateCourseDto(Guid id, string name, string description, Guid educatorId) : base(name, description)
    {
        Id = id;
        EducatorId = educatorId;
    }
}