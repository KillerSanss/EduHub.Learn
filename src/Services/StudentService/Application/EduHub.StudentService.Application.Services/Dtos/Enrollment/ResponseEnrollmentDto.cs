namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто зачисления
/// </summary>
/// <param name="Id">Идентификатор зачисления.</param>
/// <param name="StartDate">Дата начала курса.</param>
/// <param name="CourseId">Идентификатор курса.</param>
/// <param name="Name">Название курса.</param>
public record ResponseEnrollmentDto(
    Guid Id,
    DateTime StartDate,
    Guid CourseId,
    string Name);