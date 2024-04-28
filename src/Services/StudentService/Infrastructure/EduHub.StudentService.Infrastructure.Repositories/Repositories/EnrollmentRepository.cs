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
    public EnrollmentRepository(StudentDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Получение всех зачислений студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив зачислений студента.</returns>
    public async Task<Enrollment[]> GetStudentEnrollmentsAsync(Guid id, CancellationToken cancellationToken)
    {
        return await DbContext.Set<Enrollment>().Where(e => e.StudentId == id).ToArrayAsync(cancellationToken);
    }
}