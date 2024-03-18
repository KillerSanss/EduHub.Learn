using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Интерфейс описывающий CourseService
/// </summary>
public interface ICourseService
{
    /// <summary>
    /// Добавлние нового курса
    /// </summary>
    /// <param name="courseDto">Дто курса.</param>
    Task<CourseDto> AddAsync(CourseDto courseDto, CancellationToken token);

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseDto">Дто курса.</param>
    Task<CourseDto> UpdateAsync(CourseDto courseDto, CancellationToken token);

    /// <summary>
    /// Получение курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    Task<CourseDto> GetAsync(Guid courseId);

    /// <summary>
    /// Получение всех курсов
    /// </summary>
    Task<CourseDto[]> GetAllAsync();

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    Task DeleteAsync(Guid courseId, CancellationToken token);
}