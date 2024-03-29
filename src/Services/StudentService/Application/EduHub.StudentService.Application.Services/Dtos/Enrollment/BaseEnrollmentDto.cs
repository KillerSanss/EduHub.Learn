namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Базовое дто для зачисления
/// </summary>
/// <param name="Id">Идентификатор зачисления.</param>
/// <param name="StartDate">Дата зачисления.</param>
/// <param name="CourseId">Идентификатор курса.</param>
public record BaseEnrollmentDto(
    Guid Id,
    DateTime StartDate,
    Guid CourseId);