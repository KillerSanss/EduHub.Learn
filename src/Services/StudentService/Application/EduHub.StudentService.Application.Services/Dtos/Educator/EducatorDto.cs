namespace EduHub.StudentService.Application.Services.Dtos.Educator;

/// <summary>
/// Дто класс для преподавателя
/// </summary>
public class EducatorDto : BaseEducatorDto
{
    /// <summary>
    /// Идентификатор преподавателя
    /// </summary>
    public Guid Id { get; init; }
}