namespace EduHub.StudentService.Infrastructure.Repositories;

using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Infrastructure.Data.Context;

/// <summary>
/// Реализция IUnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly StudentDbContext _dbContext;

    public UnitOfWork(StudentDbContext dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }

    /// <summary>
    /// Сохранение изменений
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Кол-во изменных записей.</returns>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }
}