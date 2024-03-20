using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Интерфейс описывающий EducatorService
/// </summary>
public interface IEducatorService
{
    /// <summary>
    /// Добавлние нового преподавателя
    /// </summary>
    /// <param name="educator">record преподавателя.</param>
    Task<EducatorDto> AddAsync(EducatorDto educator, CancellationToken token);

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educator">record преподавателя.</param>
    Task<EducatorDto> UpdateAsync(EducatorDto educator, CancellationToken token);

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    Task<EducatorDto> GetAsync(Guid educatorId);

    /// <summary>
    /// Получение всех преподавателей
    /// </summary>
    Task<EducatorDto[]> GetAllAsync();

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    Task DeleteAsync(Guid educatorId, CancellationToken token);
}