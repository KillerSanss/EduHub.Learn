using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Репозиторий зачисления
/// </summary>
public class EnrollmentRepository : BaseRepository<Enrollment>, IEnrollmentRepository
{
    private readonly StudentDbContext _dbContext;

    public EnrollmentRepository(StudentDbContext dbContext) : base(dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
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
}