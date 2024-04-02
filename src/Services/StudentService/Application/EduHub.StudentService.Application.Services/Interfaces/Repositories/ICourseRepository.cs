using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Interfaces.Repositories;

/// <summary>
/// Интерфейс описывающий CourseRepository
/// </summary>
public interface ICourseRepository : IRepository<Course>
{
    /// <summary>
    /// Получение всех курсов преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns></returns>
    Task<Course[]> GetAllByEducatorIdAsync(Guid id, CancellationToken cancellationToken);
}