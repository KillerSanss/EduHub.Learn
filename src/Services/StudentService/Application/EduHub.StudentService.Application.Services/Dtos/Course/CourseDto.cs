namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
public record CourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Идентифакатор преподавателя
    /// </summary>
    public Guid EducatorId { get; init; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="name">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    /// <param name="educatorId">Идентифакатор преподавателя.</param>
    public CourseDto(Guid id, string name, string description, Guid educatorId) : base(name, description)
    {
        Id = id;
        EducatorId = educatorId;
    }
}