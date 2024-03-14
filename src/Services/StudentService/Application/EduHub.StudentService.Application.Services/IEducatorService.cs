using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий EducatorService
/// </summary>
public interface IEducatorService
{
    Task<Educator> AsyncAddEducator(EducatorDto educatorDto);
    Task<Educator> AsyncUpdateEducator(EducatorDto educatorDto);
    Task<Educator> AsyncGetEducator(Guid educatorId);
    Task<List<Educator>> AsyncGetAllEducators();
    Task<Educator> AsyncDeleteEducator(Guid educatorId);
}