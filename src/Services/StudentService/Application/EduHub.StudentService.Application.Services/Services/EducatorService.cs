using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.IServices;
using EduHub.StudentService.Application.Services.Repositories;
using EduHub.StudentService.Application.Services.UnitOfWork;
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
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление нового преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный преподаватель.</returns>
    public async Task<EducatorDto> AddAsync(EducatorDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);

        var educator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.AddAsync(educator, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<EducatorDto>(educator);
    }

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public async Task<EducatorDto> UpdateAsync(EducatorDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);

        var educator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.UpdateAsync(educator, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<EducatorDto>(educator);
    }

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="educatorId">Индентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Преподаватель.</returns>
    public async Task<EducatorDto> GetAsync(Guid educatorId, CancellationToken cancellationToken)
    {
        var educator = await _educatorRepository.GetByIdAsync(educatorId, cancellationToken);
        if (educator == null)
        {
            throw new EntityNotFoundException<Course>(nameof(educatorId), educatorId.ToString());
        }

        return _mapper.Map<EducatorDto>(educator);
    }

    /// <summary>
    /// Получение всех существующих преподавателей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех преподавателей.</returns>
    public async Task<EducatorDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var educators = await _educatorRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<EducatorDto[]>(educators);
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid educatorId, CancellationToken cancellationToken)
    {
        var educator = await _educatorRepository.GetByIdAsync(educatorId, cancellationToken);
        if (educator == null)
        {
            throw new EntityNotFoundException<Course>(nameof(educatorId), educatorId.ToString());
        }

        await _educatorRepository.DeleteAsync(educator, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}