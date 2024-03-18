using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий зачисления
/// </summary>
public class EnrollmentRepository : IEnrollmentRepository
{
    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="enrollment">Зачисление на удаление.</param>
    public Task DeleteAsync(Enrollment enrollment, CancellationToken token)
    {
        return Task.CompletedTask;
    }

    /// <summary>
    /// Получение зачисления
    /// </summary>
    /// <param name="enrollmentId">Идентификатор зачисления.</param>
    /// <returns>Зачисление.</returns>
    public Task<Enrollment> GetByIdAsync(Guid enrollmentId)
    {
        return Task.FromResult<Enrollment>(null);
    }

    /// <summary>
    /// Получение всех зачислений
    /// </summary>
    /// <returns>Массив зачислений.</returns>
    public Task<Enrollment[]> GetAllAsync()
    {
        return Task.FromResult(Array.Empty<Enrollment>());
    }

    /// <summary>
    /// Получение всех зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Массив зачислений студента.</returns>
    public Task<Enrollment[]> GetStudentEnrollmentsAsync(Guid studentId)
    {
        return Task.FromResult(Array.Empty<Enrollment>());
    }

    /// <summary>
    /// Зачисление студента на курс
    /// </summary>
    public Task EnrollStudentAsync(CancellationToken token)
    {
        return Task.CompletedTask;
    }
}