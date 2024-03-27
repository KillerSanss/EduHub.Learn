using EduHub.StudentService.Application.Services.Dtos.Enrollment;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

/// <summary>
/// Интерфейс описывающий EnrollmentService
/// </summary>
public interface IEnrollmentService
{
    /// <summary>
    /// Зачисление студента на выбранный курс
    /// </summary>
    /// <param name="enrollment">Дто зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task<EnrollmentDto> AddAsync(CreateEnrollmentDto enrollment, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив зачислений студента.</returns>
    Task<EnrollmentDto[]> GetStudentEnrollmentsAsync(Guid studentId, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех зачислений
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив зачислений.</returns>
    Task<EnrollmentDto[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="enrollmentId">Идентификатор зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Guid enrollmentId, CancellationToken cancellationToken);
}