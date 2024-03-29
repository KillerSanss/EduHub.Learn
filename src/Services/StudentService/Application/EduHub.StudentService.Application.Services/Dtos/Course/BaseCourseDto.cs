namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Базовое дто для курса
/// </summary>
/// <param name="Name">Название курса.</param>
/// <param name="Description">Описание курса.</param>
public record BaseCourseDto(
    string Name,
    string Description);