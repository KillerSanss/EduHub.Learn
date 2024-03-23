using EduHub.StudentService.Application.Services.Dtos.Course;

namespace EduHub.StudentService.Application.Services.Interfaces.IServices;

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
    Task<CreateCourseDto> AddAsync(CreateCourseDto course, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="course">Дто Курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    Task<UpdateCourseDto> UpdateAsync(UpdateCourseDto course, CancellationToken cancellationToken);

    /// <summary>
    /// Получение курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный курс.</returns>
    Task<CreateCourseDto> GetByIdAsync(Guid courseId, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив курсов.</returns>
    Task<CreateCourseDto[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Guid courseId, CancellationToken cancellationToken);
}