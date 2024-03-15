using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий EducatorService
/// </summary>
public interface IEducatorService
{
    Task<EducatorDto> AsyncAddEducator(EducatorDto educatorDto);
    Task<EducatorDto> AsyncUpdateEducator(EducatorDto educatorDto);
    Task<EducatorDto> AsyncGetEducator(Guid educatorId);
    Task<List<EducatorDto>> AsyncGetAllEducators();
    Task AsyncDeleteEducator(Guid educatorId);
}