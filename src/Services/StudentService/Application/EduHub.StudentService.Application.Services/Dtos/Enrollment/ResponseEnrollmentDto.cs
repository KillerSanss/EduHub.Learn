namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто зачисления
/// </summary>
public record ResponseEnrollmentDto : BaseEnrollmentDto
{
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="startDate">Дата зачисления.</param>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="name">Название курса.</param>
    public ResponseEnrollmentDto(
        Guid id,
        DateTime startDate,
        Guid courseId,
        string name) : base(id, startDate, courseId)
    {
        Name = name;
    }
}