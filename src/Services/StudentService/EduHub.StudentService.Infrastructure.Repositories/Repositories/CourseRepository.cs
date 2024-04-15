using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using EduHub.StudentService.Infrastructure.Repositories.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Репозиторий курса
/// </summary>
public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    private readonly StudentDbContext _dbContext;

    public CourseRepository(StudentDbContext dbContext): base(dbContext)
    {
        _dbContext = Guard.Against.Null(dbContext);
    }

    /// <summary>
    /// Получение всех курсов преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех курсов преподавателя.</returns>
    public async Task<Course[]> GetAllByEducatorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Courses.Where(c => c.EducatorId == id).ToArrayAsync(cancellationToken);
    }
}