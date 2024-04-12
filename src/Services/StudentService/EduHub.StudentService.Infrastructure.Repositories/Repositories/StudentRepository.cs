using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace EduHub.StudentService.Infrastructure.Repositories.Repositories;

/// <summary>
/// Репозиторий студента
/// </summary>
public class StudentRepository : IStudentRepository
{
    private readonly StudentDbContext _dbContext;
    private readonly IUnitOfWork _unitOfWork;

    public StudentRepository(StudentDbContext dbContext, IUnitOfWork unitOfWork)
    {
        _dbContext = Guard.Against.Null(dbContext);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление студента в базу данных
    /// </summary>
    /// <param name="student">Студент для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный студент.</returns>
    public async Task<Student> AddAsync(Student student, CancellationToken cancellationToken)
    {
        await _dbContext.Students.AddAsync(student, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return student;
    }

    /// <summary>
    /// Обновление студента в базе данных
    /// </summary>
    /// <param name="student">Студент для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<Student> UpdateAsync(Student student, CancellationToken cancellationToken)
    {
        _dbContext.Students.UpdateRange(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return student;
    }

    /// <summary>
    /// Получение всех студентов из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех студентов.</returns>
    public async Task<Student[]> GetAllAsync(CancellationToken cancellationToken)
    {
       return await _dbContext.Students.ToArrayAsync(cancellationToken);
    }

    /// <summary>
    /// Получение студента из базы по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Студент.</returns>
    public async Task<Student> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbContext.Students.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    }

    /// <summary>
    /// Удаление студента из базы данных
    /// </summary>
    /// <param name="student">Студент для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Student student, CancellationToken cancellationToken)
    {
        _dbContext.Students.Remove(student);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}