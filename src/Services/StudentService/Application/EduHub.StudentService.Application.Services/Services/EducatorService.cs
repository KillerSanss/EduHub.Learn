using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Repositories;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис преподавателя
/// </summary>
public class EducatorService : IEducatorService
{
    private readonly IEducatorRepository _educatorRepository;
    private readonly IMapper _mapper;

    public EducatorService(IEducatorRepository educatorRepository, IMapper mapper)
    {
        _educatorRepository = educatorRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление нового преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для добавления.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public async Task<EducatorDto> AsyncAddEducator(EducatorDto educatorDto)
    {
        var existingEducator = await _educatorRepository.GetEducatorById(educatorDto.Id);
        if (existingEducator != null)
        {
            throw new EntityConflictException<EducatorDto>(educatorDto, "Educator is already exist");
        }

        var newEducator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.AddEducator(newEducator);

        return _mapper.Map<EducatorDto>(newEducator);
    }

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для обновления.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public async Task<EducatorDto> AsyncUpdateEducator(EducatorDto educatorDto)
    {
        var updatedEducator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.UpdateEducator(updatedEducator);

        return _mapper.Map<EducatorDto>(updatedEducator);
    }

    /// <summary>
    /// Выбор преподавателя
    /// </summary>
    /// <param name="educatorId">Индентификатор преподавателя.</param>
    /// <returns>Выбранный преподаватель.</returns>
    public async Task<EducatorDto> AsyncGetEducator(Guid educatorId)
    {
        var existingEducator = await _educatorRepository.GetEducatorById(educatorId);
        if (existingEducator == null)
        {
            throw new EntityNotFoundException<Guid>(educatorId, "Educator does not exist");
        }

        return _mapper.Map<EducatorDto>(existingEducator);
    }

    /// <summary>
    /// Выбор всех существующих преподавателей
    /// </summary>
    /// <returns>Список всех преподавателей.</returns>
    public async Task<List<EducatorDto>> AsyncGetAllEducators()
    {
        var allEducators = await _educatorRepository.GetAllEducators();

        return _mapper.Map<List<EducatorDto>>(allEducators);
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    public async Task AsyncDeleteEducator(Guid educatorId)
    {
        var deletedEducator = await _educatorRepository.GetEducatorById(educatorId);
        if (deletedEducator == null)
        {
            throw new EntityNotFoundException<Guid>(educatorId, "Educator does not exist");
        }

        await _educatorRepository.DeleteEducator(educatorId);
    }
}