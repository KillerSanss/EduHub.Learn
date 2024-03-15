using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using Eduhub.StudentService.Domain.Entities;
using AutoMapper;
using EduHub.StudentService.Application.Services.Exceptions;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис курса
/// </summary>
public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public CourseService(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление нового курса
    /// </summary>
    /// <param name="courseDto">Курс для добавления.</param>
    /// <returns>Добавленный курс.</returns>
    public async Task<CourseDto> AsyncAddCourse(CourseDto courseDto)
    {
        var existingCourse = await _courseRepository.GetCourseById(courseDto.Id);
        if (existingCourse != null)
        {
            throw new EntityConflictException<CourseDto>(courseDto, "Course is already exists");
        }

        var newCourse = _mapper.Map<Course>(courseDto);
        await _courseRepository.AddCourse(newCourse);

        return _mapper.Map<CourseDto>(newCourse);
    }

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseDto">Курс для обновления.</param>
    /// <returns>Обновленный курс.</returns>
    public async Task<CourseDto> AsyncUpdateCourse(CourseDto courseDto)
    {
        var updatedCourse = _mapper.Map<Course>(courseDto);
        await _courseRepository.UpdateCourse(updatedCourse);

        return _mapper.Map<CourseDto>(updatedCourse);
    }

    /// <summary>
    /// Выбор одного курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <returns>Выбранный курс.</returns>
    public async Task<CourseDto> AsyncGetCourse(Guid courseId)
    {
        var existingCourse = await _courseRepository.GetCourseById(courseId);
        if (existingCourse == null)
        {
            throw new EntityNotFoundException<Guid>(courseId, "Course does not exist");
        }

        return _mapper.Map<CourseDto>(existingCourse);
    }

    /// <summary>
    /// Выбор списка курса
    /// </summary>
    /// <returns>Список всех существующих курсов.</returns>
    public async Task<List<CourseDto>> AsyncGetAllCourses()
    {
        var allCourses = await _courseRepository.GetAllCourses();

        return _mapper.Map<List<CourseDto>>(allCourses);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Курс для удаления.</param>
    public async Task AsyncDeleteCourse(Guid courseId)
    {
        var deletedCourse = await _courseRepository.GetCourseById(courseId);
        if (deletedCourse == null)
        {
            throw new EntityNotFoundException<Guid>(courseId, "Course does not exist");
        }

        await _courseRepository.DeleteCourse(courseId);
    }
}