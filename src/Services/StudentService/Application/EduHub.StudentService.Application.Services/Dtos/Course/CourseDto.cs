namespace EduHub.StudentService.Application.Services.Dtos.Course;

/// <summary>
/// Дто класс для курса
/// </summary>
/// <param name="Id">Идентификатор.</param>
/// <param name="Name">Название.</param>
/// <param name="Description">Описание.</param>
/// <param name="EducatorId">Идентификатор преподавателя.</param>
public record CourseDto(
    Guid Id,
    string Name,
    string Description,
    Guid EducatorId);
