using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using EduHub.StudentService.Application.Services.UOW;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис преподавателя
/// </summary>
public class EducatorService : IEducatorService
{
    private readonly IEducatorRepository _educatorRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EducatorService(IEducatorRepository educatorRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _educatorRepository = Guard.Against.Null(educatorRepository);
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Добавление нового преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для добавления.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public async Task<EducatorDto> AddAsync(EducatorDto educatorDto, CancellationToken token)
    {
        Guard.Against.Null(educatorDto);

        var newEducator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.AddAsync(newEducator, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<EducatorDto>(newEducator);
    }

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для обновления.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public async Task<EducatorDto> UpdateAsync(EducatorDto educatorDto, CancellationToken token)
    {
        Guard.Against.Null(educatorDto);

        var updatedEducator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.UpdateAsync(updatedEducator, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<EducatorDto>(updatedEducator);
    }

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Индентификатор преподавателя.</param>
    /// <returns>Преподаватель.</returns>
    public async Task<EducatorDto> GetAsync(Guid educatorId)
    {
        var educator = await _educatorRepository.GetByIdAsync(educatorId);
        if (educator == null)
        {
            throw new EntityNotFoundException<Course>(nameof(educatorId), educatorId.ToString());
        }

        return _mapper.Map<EducatorDto>(educator);
    }

    /// <summary>
    /// Получение всех существующих преподавателей
    /// </summary>
    /// <returns>Массив всех преподавателей.</returns>
    public async Task<EducatorDto[]> GetAllAsync()
    {
        var educators = await _educatorRepository.GetAllAsync();
        return _mapper.Map<EducatorDto[]>(educators);
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    public async Task DeleteAsync(Guid educatorId, CancellationToken token)
    {
        var deletedEducator = await _educatorRepository.GetByIdAsync(educatorId);
        if (deletedEducator == null)
        {
            throw new EntityNotFoundException<Course>(nameof(educatorId), educatorId.ToString());
        }

        await _educatorRepository.DeleteAsync(deletedEducator, token);
        await _unitOfWork.SaveChangesAsync(token);
    }
}