using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services.IServices;

/// <summary>
/// Интерфейс описывающий CourseService
/// </summary>
public interface ICourseService
{
    /// <summary>
    /// Добавлние нового курса
    /// </summary>
    /// <param name="course">Дто Курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный курс.</returns>
    Task<CourseDto> AddAsync(CourseDto course, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="course">Дто Курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    Task<CourseDto> UpdateAsync(CourseDto course, CancellationToken cancellationToken);

    /// <summary>
    /// Получение курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный курс.</returns>
    Task<CourseDto> GetByIdAsync(Guid courseId, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив курсов.</returns>
    Task<CourseDto[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Guid courseId, CancellationToken cancellationToken);
}