using EduHub.StudentService.Application.Services.Dtos.Educator;

namespace EduHub.StudentService.Application.Services.Interfaces.Services;

/// <summary>
/// Интерфейс описывающий EducatorService
/// </summary>
public interface IEducatorService
{
    /// <summary>
    /// Добавлние нового преподавателя
    /// </summary>
    /// <param name="educator">Дто Преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный преподаватель.</returns>
    Task<EducatorDto> AddAsync(CreateEducatorDto educator, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educator">Дто Преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    Task<EducatorDto> UpdateAsync(UpdateEducatorDto educator, CancellationToken cancellationToken);

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный преподаватель.</returns>
    Task<EducatorDto> GetByIdAsync(Guid educatorId, CancellationToken cancellationToken);

    /// <summary>
    /// Получение всех преподавателей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив преподавателей.</returns>
    Task<EducatorDto[]> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    Task DeleteAsync(Guid educatorId, CancellationToken cancellationToken);
}