using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий студента
/// </summary>
public class StudentRepository : IStudentRepository
{
    /// <summary>
    /// Добавление студента
    /// </summary>
    /// <param name="student">Студент на добавление.</param>
    /// <returns>Добавленный студент.</returns>
    public Task<Student> AddAsync(Student student, CancellationToken token)
    {
        return Task.FromResult(student);
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="student">Студент на обновление.</param>
    /// <returns>Обновленный студент.</returns>
    public Task<Student> UpdateAsync(Student student, CancellationToken token)
    {
        return Task.FromResult(student);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="student">Студент на удаление.</param>
    public Task DeleteAsync(Student student, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Выбранный студент.</returns>
    public Task<Student> GetByIdAsync(Guid studentId)
    {
        return Task.FromResult<Student>(null);
    }

    /// <summary>
    /// Получение всех студентов
    /// </summary>
    /// <returns>Массив студентов.</returns>
    public Task<Student[]> GetAllAsync()
    {
        return Task.FromResult(Array.Empty<Student>());
    }
}