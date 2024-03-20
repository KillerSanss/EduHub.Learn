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
    /// <param name="educator">Преподаватель для добавления.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public async Task<EducatorRecord> AddAsync(EducatorRecord educator, CancellationToken token)
    {
        Guard.Against.Null(educator);

        var newEducator = _mapper.Map<Educator>(educator with { EducatorId = Guid.NewGuid()});
        await _educatorRepository.AddAsync(newEducator, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<EducatorRecord>(newEducator);
    }

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educator">Преподаватель для обновления.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public async Task<EducatorRecord> UpdateAsync(EducatorRecord educator, CancellationToken token)
    {
        Guard.Against.Null(educator);

        var updatedEducator = _mapper.Map<Educator>(educator with { EducatorId = Guid.NewGuid()});
        await _educatorRepository.UpdateAsync(updatedEducator, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<EducatorRecord>(updatedEducator);
    }

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Индентификатор преподавателя.</param>
    /// <returns>Преподаватель.</returns>
    public async Task<EducatorRecord> GetAsync(Guid educatorId)
    {
        var educator = await _educatorRepository.GetByIdAsync(educatorId);
        if (educator == null)
        {
            throw new EntityNotFoundException<Course>(nameof(educatorId), educatorId.ToString());
        }

        return _mapper.Map<EducatorRecord>(educator);
    }

    /// <summary>
    /// Получение всех существующих преподавателей
    /// </summary>
    /// <returns>Массив всех преподавателей.</returns>
    public async Task<EducatorRecord[]> GetAllAsync()
    {
        var educators = await _educatorRepository.GetAllAsync();
        return _mapper.Map<EducatorRecord[]>(educators);
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