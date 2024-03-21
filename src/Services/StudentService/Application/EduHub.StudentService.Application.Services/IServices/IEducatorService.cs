using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services.IServices;

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
    Task<EducatorDto> AddAsync(EducatorDto educator, CancellationToken cancellationToken);

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educator">Дто Преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    Task<EducatorDto> UpdateAsync(EducatorDto educator, CancellationToken cancellationToken);

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный преподаватель.</returns>
    Task<EducatorDto> GetAsync(Guid educatorId, CancellationToken cancellationToken);

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