using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Интерфейс описывающий EnrollmentRepository
/// </summary>
public interface IEnrollmentRepository
{
    /// <summary>
    /// Выбор всех зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Массив всех зачислений студента.</returns>
    Task<Enrollment[]> GetStudentEnrollmentsAsync(Guid studentId);

    /// <summary>
    /// Зачисление студента
    /// </summary>
    Task EnrollStudentAsync(CancellationToken token);

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="entity">Зачисление на удаление.</param>
    Task DeleteAsync(Enrollment entity, CancellationToken token);

    /// <summary>
    /// Получение всех существующих зачислений
    /// </summary>
    /// <returns>Массив всех зачислений.</returns>
    Task<Enrollment[]> GetAllAsync();

    /// <summary>
    /// Выбор одного зачисления
    /// </summary>
    /// <param name="enrollmentId">Идентификатор зачисления.</param>
    /// <returns>Выбранное зачисление.</returns>
    Task<Enrollment> GetByIdAsync(Guid enrollmentId);
}