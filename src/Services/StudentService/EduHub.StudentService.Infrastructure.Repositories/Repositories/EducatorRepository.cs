using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Рпозиторий преподавателя
/// </summary>
public class EducatorRepository : IEducatorRepository
{
    private readonly StudentDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public EducatorRepository(StudentDbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = Guard.Against.Null(dbContext);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление преподавателя в базу данных
    /// </summary>
    /// <param name="educator">Преподаватель для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public async Task<Educator> AddAsync(Educator educator, CancellationToken cancellationToken)
    {
        await _dbContext.Educators.AddAsync(educator, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return educator;
    }

    /// <summary>
    /// Обновление преподавателя в базе данных
    /// </summary>
    /// <param name="educator">Преподаватель для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public async Task<Educator> UpdateAsync(Educator educator, CancellationToken cancellationToken)
    {
        _dbContext.Educators.UpdateRange(educator);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return educator;
    }

    /// <summary>
    /// Получение всех преподавателей из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех преподавателей.</returns>
    public async Task<Educator[]> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Educators.ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Получение преподавателя из базы по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Преподаватель.</returns>
    public async Task<Educator> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Educators.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <summary>
    /// Удаление преподавателя из базы данных
    /// </summary>
    /// <param name="educator">Преподаватель для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Educator educator, CancellationToken cancellationToken)
    {
        _dbContext.Educators.Remove(educator);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}