namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто класс для зачисления
/// </summary>
public class EnrollmentDto : BaseEnrollmentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid StudentId { get; init; }
}