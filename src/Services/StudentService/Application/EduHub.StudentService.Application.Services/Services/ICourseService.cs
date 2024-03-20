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
    /// <param name="course">record Курса.</param>
    Task<CourseRecord> AddAsync(CourseRecord course, CancellationToken token);

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="course">record Курса.</param>
    Task<CourseRecord> UpdateAsync(CourseRecord course, CancellationToken token);

    /// <summary>
    /// Получение курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    Task<CourseRecord> GetAsync(Guid courseId);

    /// <summary>
    /// Получение всех курсов
    /// </summary>
    Task<CourseRecord[]> GetAllAsync();

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    Task DeleteAsync(Guid courseId, CancellationToken token);
}