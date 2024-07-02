namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Базовое дто для зачисления
/// </summary>
public abstract class BaseEnrollmentDto
{
    /// <summary>
    /// Дата зачисления
    /// </summary>
    public DateTime StartDate { get; init; }

    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid CourseId { get; init; }
}