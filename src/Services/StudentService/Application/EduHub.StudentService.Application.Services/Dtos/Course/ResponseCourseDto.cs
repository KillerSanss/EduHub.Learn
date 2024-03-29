namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто курса
/// </summary>
public record ResponseCourseDto : BaseCourseDto
{
    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="name">Название курса.</param>
    /// <param name="description">Описание курса.</param>
    public ResponseCourseDto(Guid id, string name, string description) : base(name, description)
    {
        Id = id;
    }
}