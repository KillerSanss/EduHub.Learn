using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий преподавателя
/// </summary>
public class EducatorRepository : IEducatorRepository
{
    /// <summary>
    /// Добавление преподавателя
    /// </summary>
    /// <param name="educator">Преподаватель на добавление.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public Task<Educator> AddAsync(Educator educator, CancellationToken token)
    {
        return Task.FromResult(educator);
    }

    /// <summary>
    /// Обновленеи преподавателя
    /// </summary>
    /// <param name="educator">Преподаватль на обновление.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public Task<Educator> UpdateAsync(Educator educator, CancellationToken token)
    {
        return Task.FromResult(educator);
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="educator">Преподаватель на удаление.</param>
    public Task DeleteAsync(Educator educator, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <returns>Преподаватель.</returns>
    public Task<Educator> GetByIdAsync(Guid educatorId)
    {
        return Task.FromResult<Educator>(null);
    }

    /// <summary>
    /// Получение всех преподавателей
    /// </summary>
    /// <returns>Массив преподавателей.</returns>
    public Task<Educator[]> GetAllAsync()
    {
        return Task.FromResult(Array.Empty<Educator>());
    }
}