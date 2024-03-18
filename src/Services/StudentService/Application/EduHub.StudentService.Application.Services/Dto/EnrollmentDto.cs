namespace EduHub.StudentService.Application.Services.Dto;

/// <summary>
/// Dto класс для зачисления
/// </summary>
public class EnrollmentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid StudentId { get; init; }

    /// <summary>
    /// Идентификатор курса
    /// </summary>
    public Guid CourseId { get; init; }

    /// <summary>
    /// Дата зачисления
    /// </summary>
    public DateTime StartDate { get; init; }
}