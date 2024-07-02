using EduHub.StudentService.Application.Services.Dtos.Student;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

/// <summary>
/// Интерфейс описывающий StudentService
/// </summary>
public interface IStudentService
{
    /// <summary>
    /// Добавлние нового студента
    /// </summary>
    /// <param name="student">Дто студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный студент.</returns>
    Task<StudentDto> AddAsync(UpsertStudentDto student, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="student">Дто студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    Task<StudentDto> UpdateAsync(Guid studentId, UpsertStudentDto student, CancellationToken  cancellationToken = default);

    /// <summary>
    /// Получение студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный студент.</returns>
    Task<StudentDto> GetByIdAsync(Guid studentId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получение всех студентов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив студентов.</returns>
    Task<StudentDto[]> GetAllAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Guid studentId, CancellationToken cancellationToken = default);
}