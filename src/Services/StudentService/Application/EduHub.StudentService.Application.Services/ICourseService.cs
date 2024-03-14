using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий CourseService
/// </summary>
public interface ICourseService
{
    Task<Course> AsyncAddCourse(CourseDto courseDto);
    Task<Course> AsyncUpdateCourse(CourseDto courseDto);
    Task<Course> AsyncGetCourse(Guid courseId);
    Task<List<Course>> AsyncGetAllCourses();
    Task<Course> AsyncDeleteCourse(Guid courseId);
}