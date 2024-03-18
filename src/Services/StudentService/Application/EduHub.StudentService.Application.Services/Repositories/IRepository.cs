namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Базовый репозиторий
/// </summary>
public interface IRepository<TEntity>
{
    /// <summary>
    /// Выбор одного
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <returns>Выбранная сущность.</returns>
    Task<TEntity> GetByIdAsync(Guid id);

    /// <summary>
    /// Добавление
    /// </summary>
    /// <param name="entity">Сущность на добавление.</param>
    /// <returns>Добавленная сущность.</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken token);

    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="entity">Сущность на обновление.</param>
    /// <returns>Обновленная сущнсть.</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken token);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="entity">Сущность на удаление.</param>
    Task DeleteAsync(TEntity entity, CancellationToken token);

    /// <summary>
    /// Выбор всех существующих сущностей
    /// </summary>
    /// <returns>Массив всех сущностей.</returns>
    Task<TEntity[]> GetAllAsync();
}