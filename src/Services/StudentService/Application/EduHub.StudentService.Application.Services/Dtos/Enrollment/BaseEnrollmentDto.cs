namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Базовое дто для зачисления
/// </summary>
public abstract class BaseEnrollmentDto
{
    /// <summary>
    /// Идентификатор зачисления
    /// </summary>
    public Guid Id { get; init; }

    /// <summary>
    /// Дата зачисления
    /// </summary>
    public DateTime StartDate { get; init; }

    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid CourseId { get; init; }
}