namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
/// <param name="Name">Название курса.</param>
/// <param name="Description">Описание.</param>
/// <param name="EducatorId">Идентификатор преподавателя.</param>
public record CreateCourseDto(
    string Name,
    string Description,
    Guid EducatorId);