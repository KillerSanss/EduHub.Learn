using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий преподавателя
/// </summary>
public interface IEducatorRepository
{
    Task<Educator> GetEducatorById(Guid educatorId);
    Task<Educator> AddEducator(Educator educator);
    Task<Educator> UpdateEducator(Educator educator);
    Task<List<Educator>> GetAllEducators();
    Task<Educator> DeleteEducator(Guid educatorId);
}