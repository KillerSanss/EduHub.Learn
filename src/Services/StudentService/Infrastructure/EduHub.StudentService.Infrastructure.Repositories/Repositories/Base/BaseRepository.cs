using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Entities.Base;
using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories.Base;

/// <summary>
/// Репозиторий для сущнсотей
/// </summary>
/// <typeparam name="TEntity">Сущность.</typeparam>
public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly StudentDbContext _dbContext;

    protected BaseRepository(StudentDbContext dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }

    /// <summary>
    /// Добавление в базу данных
    /// </summary>
    /// <param name="entity">Сущность для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленная сущнсоть.</returns>
    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);
        return entity;
    }

    /// <summary>
    /// Обновление сущности в базе данных
    /// </summary>
    /// <param name="entity">Сущность на обновление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность.</returns>
    public Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<TEntity>().Update(entity);
        return Task.FromResult(entity);
    }

    /// <summary>
    /// Получение всех сущностей из базы
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив сущностей.</returns>
    public async Task<TEntity[]> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Получение сущности из бд по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор сущнсоти.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность.</returns>
    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <summary>
    /// Удаление сущности из базы данных
    /// </summary>
    /// <param name="entity">Сущнсоть на удаление.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }
}