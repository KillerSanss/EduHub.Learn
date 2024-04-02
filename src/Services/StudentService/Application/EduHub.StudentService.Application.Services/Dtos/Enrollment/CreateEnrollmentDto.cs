namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто для зачисления
/// </summary>
public class CreateEnrollmentDto : BaseEnrollmentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid StudentId { get; init; }

}