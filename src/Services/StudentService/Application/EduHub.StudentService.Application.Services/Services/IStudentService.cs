using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Интерфейс описывающий StudentService
/// </summary>
public interface IStudentService
{
    /// <summary>
    /// Добавлние нового студента
    /// </summary>
    /// <param name="studentDto">Дто студента.</param>
    Task<StudentDto> AddAsync(StudentDto studentDto, CancellationToken token);

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentDto">Дто студента.</param>
    Task<StudentDto> UpdateAsync(StudentDto studentDto, CancellationToken  token);

    /// <summary>
    /// Получение студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    Task<StudentDto> GetAsync(Guid studentId);

    /// <summary>
    /// Получение всех студентов
    /// </summary>
    Task<StudentDto[]> GetAllAsync();

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    Task DeleteAsync(Guid studentId, CancellationToken token);
}