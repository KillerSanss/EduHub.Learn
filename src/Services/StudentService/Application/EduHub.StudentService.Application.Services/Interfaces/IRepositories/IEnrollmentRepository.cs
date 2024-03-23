using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces.IRepositories;

/// <summary>
/// Интерфейс описывающий EnrollmentRepository
/// </summary>
public interface IEnrollmentRepository : IRepository<Enrollment>
{
    /// <summary>
    /// Выбор всех зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех зачислений студента.</returns>
    Task<Enrollment[]> GetStudentEnrollmentsAsync(Guid studentId, CancellationToken cancellationToken);

    /// <summary>
    /// Зачисление студента
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленное зачисление.</returns>
    Task<Enrollment> AddAsync(CancellationToken cancellationToken);
}