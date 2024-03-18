using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using Eduhub.StudentService.Domain.Entities;
using AutoMapper;
using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.UOW;
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
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Добавление нового курса
    /// </summary>
    /// <param name="courseDto">Курс для добавления.</param>
    /// <returns>Добавленный курс.</returns>
    public async Task<CourseDto> AddAsync(CourseDto courseDto, CancellationToken token)
    {
        Guard.Against.Null(courseDto);

        var newCourse = _mapper.Map<Course>(courseDto);
        await _courseRepository.AddAsync(newCourse, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<CourseDto>(newCourse);
    }

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseDto">Курс для обновления.</param>
    /// <returns>Обновленный курс.</returns>
    public async Task<CourseDto> UpdateAsync(CourseDto courseDto, CancellationToken token)
    {
        Guard.Against.Null(courseDto);

        var updatedCourse = _mapper.Map<Course>(courseDto);
        await _courseRepository.UpdateAsync(updatedCourse, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<CourseDto>(updatedCourse);
    }

    /// <summary>
    /// Получение одного курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <returns>Курс.</returns>
    public async Task<CourseDto> GetAsync(Guid courseId)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(courseId), courseId.ToString());
        }

        return _mapper.Map<CourseDto>(course);
    }

    /// <summary>
    /// Получение списка курса
    /// </summary>
    /// <returns>Массив всех существующих курсов.</returns>
    public async Task<CourseDto[]> GetAllAsync()
    {
        var courses = await _courseRepository.GetAllAsync();
        return _mapper.Map<CourseDto[]>(courses);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Курс для удаления.</param>
    public async Task DeleteAsync(Guid courseId, CancellationToken token)
    {
        var deletedCourse = await _courseRepository.GetByIdAsync(courseId);
        if (deletedCourse == null)
        {
            throw new EntityNotFoundException<Course>(nameof(courseId), courseId.ToString());
        }

        await _courseRepository.DeleteAsync(deletedCourse, token);
        await _unitOfWork.SaveChangesAsync(token);
    }
}