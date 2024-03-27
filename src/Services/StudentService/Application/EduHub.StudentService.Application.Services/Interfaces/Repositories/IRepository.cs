using Eduhub.StudentService.Domain.Entities.Base;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories;

/// <summary>
/// Базовый репозиторий
/// </summary>
/// <typeparam name="TEntity">Сущность.</typeparam>
public interface IRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Выбор одного
    /// </summary>
    /// <param name="id">Идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранная сущность.</returns>
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление
    /// </summary>
    /// <param name="entity">Сущность на добавление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленная сущность.</returns>
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление
    /// </summary>
    /// <param name="entity">Сущность на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущнсть.</returns>
    Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление
    /// </summary>
    /// <param name="entity">Сущность на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(TEntity entity, CancellationToken cancellationToken);

    /// <summary>
    /// Выбор всех существующих сущностей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех сущностей.</returns>
    Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken);
}