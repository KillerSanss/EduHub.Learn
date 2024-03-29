namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто для зачисления
/// </summary>
public record CreateEnrollmentDto : BaseEnrollmentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid StudentId { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="startDate">Дата зачисления.</param>
    /// <param name="courseId">Идентификатор курса</param>
    public CreateEnrollmentDto(Guid id, Guid studentId, DateTime startDate, Guid courseId) : base(id, startDate, courseId)
    {
        StudentId = studentId;
    }
}