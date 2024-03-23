namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
/// <param name="Name">Название.</param>
/// <param name="Description">Описание.</param>
/// <param name="EducatorId">Идентификатор преподавателя.</param>
public record CourseDto(
    string Name,
    string Description,
    Guid EducatorId);
