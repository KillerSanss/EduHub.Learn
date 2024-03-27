namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто для зачисления
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="StudentId">Идентификатор студента.</param>
/// <param name="CourseId">Идентификатор курса.</param>
/// <param name="StartDate">Дата начала курса.</param>
public record CreateEnrollmentDto(
    Guid Id,
    Guid StudentId,
    Guid CourseId,
    DateTime StartDate);