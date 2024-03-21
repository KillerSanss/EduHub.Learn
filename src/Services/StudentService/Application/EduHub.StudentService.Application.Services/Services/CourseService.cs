using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using Eduhub.StudentService.Domain.Entities;
using AutoMapper;
using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.IServices;
using EduHub.StudentService.Application.Services.UnitOfWork;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис курса
/// </summary>
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(ICourseRepository courseRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _courseRepository = Guard.Against.Null(courseRepository);
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление нового курса
    /// </summary>
    /// <param name="courseDto">Курс для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный курс.</returns>
    public async Task<CourseDto> AddAsync(CourseDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);

        var course = _mapper.Map<Course>(courseDto);

        await _courseRepository.AddAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseDto>(course);
    }

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseDto">Курс для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    public async Task<CourseDto> UpdateAsync(CourseDto courseDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(courseDto);

        var course = _mapper.Map<Course>(courseDto);
        await _courseRepository.UpdateAsync(course, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<CourseDto>(course);
    }

    /// <summary>
    /// Получение одного курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Курс.</returns>
    public async Task<CourseDto> GetByIdAsync(Guid courseId, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(courseId, cancellationToken);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(courseId), courseId.ToString());
        }

        return _mapper.Map<CourseDto>(course);
    }

    /// <summary>
    /// Получение списка курса
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех существующих курсов.</returns>
    public async Task<CourseDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<CourseDto[]>(courses);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Курс для удаления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid courseId, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(courseId, cancellationToken);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(courseId), courseId.ToString());
        }

        await _courseRepository.DeleteAsync(course, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}