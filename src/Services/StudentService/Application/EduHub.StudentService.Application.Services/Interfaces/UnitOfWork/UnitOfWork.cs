using Ardalis.GuardClauses;
using Eduhub.StudentService.Infrastructure.Data.Context;

namespace EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;

/// <summary>
/// Реализация UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly StudentDbContext _dbContext;

    public UnitOfWork(StudentDbContext dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }

    /// <summary>
    /// Сохранение изменений в базу данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Кол-во изменненых записей.</returns>
    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}