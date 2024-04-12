using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Репозиторий зачисления
/// </summary>
public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly StudentDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public EnrollmentRepository(StudentDbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = Guard.Against.Null(dbContext);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление зачисления в базу данных
    /// </summary>
    /// <param name="enrollment">Зачисление для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленное зачисление.</returns>
    public async Task<Enrollment> AddAsync(Enrollment enrollment, CancellationToken cancellationToken)
    {
        await _dbContext.Enrollments.AddAsync(enrollment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return enrollment;
    }

    /// <summary>
    /// Получение всех зачислений из базы данных
    /// </summary>
    /// <returns>Массив всех зачислений.</returns>
    public async Task<Enrollment[]> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Enrollments.ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Удадление зачисления из базы данных
    /// </summary>
    /// <param name="enrollment">Зачисление для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Enrollment enrollment, CancellationToken cancellationToken)
    {
        _dbContext.Enrollments.Remove(enrollment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    /// <summary>
    /// Получение всех зачислениц студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив зачислений студента.</returns>
    public async Task<Enrollment[]> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Enrollments.Where(e => e.StudentId == id).ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Получение зачисления по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Зачисление.</returns>
    public async Task<Enrollment> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Enrollments.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <summary>
    /// Обновление зачисления в базе данных
    /// </summary>
    /// <param name="enrollment">Зачисление для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленное зачисление.</returns>
    public async Task<Enrollment> UpdateAsync(Enrollment enrollment, CancellationToken cancellationToken)
    {
        _dbContext.Enrollments.UpdateRange(enrollment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return enrollment;
    }
}