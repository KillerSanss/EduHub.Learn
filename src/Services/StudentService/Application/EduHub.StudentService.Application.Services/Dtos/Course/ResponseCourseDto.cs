namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто курса
/// </summary>
/// <param name="Id">Идентификатор курса.</param>
/// <param name="Name">Название курса.</param>
/// <param name="Description">Описание курса.</param>
public record ResponseCourseDto(
    Guid Id,
    string Name,
    string Description);