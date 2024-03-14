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
    public async Task<Course> AsyncAddCourse(CourseDto courseDto)
    {
        var existingCourse = await _courseRepository.GetCourseById(courseDto.Id);
        if (existingCourse != null)
        {
            throw new EntityConflictException<CourseDto>(courseDto, "Course is already exists");
        }

        var newCourse = _mapper.Map<Course>(courseDto);
        await _courseRepository.AddCourse(newCourse);

        return newCourse;
    }

    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="courseDto">Курс для обновления.</param>
    /// <returns>Обновленный курс.</returns>
    public async Task<Course> AsyncUpdateCourse(CourseDto courseDto)
    {
        var updatedCourse = _mapper.Map<Course>(courseDto);
        await _courseRepository.UpdateCourse(updatedCourse);

        return updatedCourse;
    }

    /// <summary>
    /// Выбор одного курса
    /// </summary>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <returns>Выбранный курс.</returns>
    public async Task<Course> AsyncGetCourse(Guid courseId)
    {
        var existingCourse = await _courseRepository.GetCourseById(courseId);
        if (existingCourse == null)
        {
            throw new EntityNotFoundException<Guid>(courseId, "Course does not exist");
        }

        return existingCourse;
    }

    /// <summary>
    /// Выбор списка курса
    /// </summary>
    /// <returns>Список всех существующих курсов.</returns>
    public async Task<List<Course>> AsyncGetAllCourses()
    {
        var allCourses = await _courseRepository.GetAllCourses();

        return _mapper.Map<List<Course>>(allCourses);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="courseId">Курс для удаления.</param>
    /// <returns>Удаленный курс.</returns>
    public async Task<Course> AsyncDeleteCourse(Guid courseId)
    {
        var deletedCourse = await _courseRepository.GetCourseById(courseId);
        if (deletedCourse == null)
        {
            throw new EntityNotFoundException<Guid>(courseId, "Course does not exist");
        }

        await _courseRepository.DeleteCourse(courseId);

        return deletedCourse;
    }
}