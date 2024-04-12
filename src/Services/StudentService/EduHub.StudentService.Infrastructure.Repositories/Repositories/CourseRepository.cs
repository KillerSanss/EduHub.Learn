using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Репозиторий курса
/// </summary>
public class CourseRepository : ICourseRepository
{
    private readonly StudentDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public CourseRepository(StudentDbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = Guard.Against.Null(dbContext);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление курса в базу данных
    /// </summary>
    /// <param name="course">Курс для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный курс.</returns>
    public async Task<Course> AddAsync(Course course, CancellationToken cancellationToken)
    {
        await _dbContext.Courses.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return course;
    }

    /// <summary>
    /// Обновление курса в базе данных
    /// </summary>
    /// <param name="course">Курс для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    public async Task<Course> UpdateAsync(Course course, CancellationToken cancellationToken)
    {
        _dbContext.Courses.UpdateRange(course);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return course;
    }

    /// <summary>
    /// Получение всех курсов из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех курсов.</returns>
    public async Task<Course[]> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Courses.ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Получение курса из базы по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Курс.</returns>
    public async Task<Course> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Courses.FirstOrDefaultAsync(с => с.Id == id, cancellationToken);
    }

    /// <summary>
    /// Удаление курса из базы данных
    /// </summary>
    /// <param name="course">Курс для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Course course, CancellationToken cancellationToken)
    {
        _dbContext.Courses.Remove(course);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
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