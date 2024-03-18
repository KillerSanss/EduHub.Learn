using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий курса
/// </summary>
public class CourseRepository : ICourseRepository
{
    /// <summary>
    /// Добавление курса
    /// </summary>
    /// <param name="course">Курс на добавление.</param>
    /// <returns>Добавленный курс.</returns>
    public Task<Course> AddAsync(Course course, CancellationToken token)
    {
        return Task.FromResult(course);
    }

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="course">Курс на обновление.</param>
    /// <returns>Обновленный курс.</returns>
    public Task<Course> UpdateAsync(Course course, CancellationToken token)
    {
        return Task.FromResult(course);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="course">Курс на удаление.</param>
    public Task DeleteAsync(Course course, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <returns>Курс.</returns>
    public Task<Course> GetByIdAsync(Guid courseId)
    {
        return Task.FromResult<Course>(null);
    }

    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <returns>Массив курсов.</returns>
    public Task<Course[]> GetAllAsync()
    {
        return Task.FromResult(Array.Empty<Course>());
    }
}