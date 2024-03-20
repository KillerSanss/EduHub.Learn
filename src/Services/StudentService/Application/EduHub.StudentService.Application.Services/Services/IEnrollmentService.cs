using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Интерфейс описывающий EnrollmentService
/// </summary>
public interface IEnrollmentService
{
    /// <summary>
    /// Зачисление студента на выбранный курс
    /// </summary>
    /// <param name="enrollment">record зачисления.</param>
    Task EnrollStudentAsync(EnrollmentDto enrollment, CancellationToken token);

    /// <summary>
    /// Получение всех зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    Task<EnrollmentDto[]> GetStudentEnrollmentsAsync(Guid studentId);

    /// <summary>
    /// Получение всех зачислений
    /// </summary>
    Task<EnrollmentDto[]> GetAllAsync();

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="enrollmentId">Идентификатор зачисления.</param>
    Task DeleteAsync(Guid enrollmentId, CancellationToken token);
}