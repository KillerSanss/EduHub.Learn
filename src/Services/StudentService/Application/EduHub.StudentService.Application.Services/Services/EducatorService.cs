using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using EduHub.StudentService.Application.Services.Interfaces.IRepositories;
using EduHub.StudentService.Application.Services.Interfaces.IServices;
using EduHub.StudentService.Application.Services.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
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
    public async Task<CreateEducatorDto> AddAsync(CreateEducatorDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);

        var educator = _mapper.Map<Educator>(educatorDto);
        await _educatorRepository.AddAsync(educator, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CreateEducatorDto>(educator);
    }

    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="educatorDto">Преподаватель для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    public async Task<UpdateEducatorDto> UpdateAsync(UpdateEducatorDto educatorDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(educatorDto);

        var educator = _mapper.Map<Educator>(educatorDto);
        educator.Update(
            new FullName(educatorDto.Surname, educatorDto.FirstName, educatorDto.Patronymic),
            educatorDto.Gender,
            educatorDto.WorkExperience,
            educatorDto.StartDate,
            new Phone(educatorDto.Phone));

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<UpdateEducatorDto>(educator);
    }

    /// <summary>
    /// Получение преподавателя
    /// </summary>
    /// <param name="id">Индентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Преподаватель.</returns>
    public async Task<CreateEducatorDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var educator = await _educatorRepository.GetByIdAsync(id, cancellationToken);
        if (educator == null)
        {
            throw new EntityNotFoundException<Educator>(nameof(Educator.Id), id.ToString());
        }

        return _mapper.Map<CreateEducatorDto>(educator);
    }

    /// <summary>
    /// Получение всех существующих преподавателей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех преподавателей.</returns>
    public async Task<CreateEducatorDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var educators = await _educatorRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<CreateEducatorDto[]>(educators);
    }

    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var educator = await _educatorRepository.GetByIdAsync(id, cancellationToken);
        if (educator == null)
        {
            throw new EntityNotFoundException<Educator>(nameof(Educator.Id), id.ToString());
        }

        await _educatorRepository.DeleteAsync(educator, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}