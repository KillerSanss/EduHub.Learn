using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий CourseService
/// </summary>
public interface ICourseService
{
    Task<CourseDto> AsyncAddCourse(CourseDto courseDto);
    Task<CourseDto> AsyncUpdateCourse(CourseDto courseDto);
    Task<CourseDto> AsyncGetCourse(Guid courseId);
    Task<List<CourseDto>> AsyncGetAllCourses();
    Task AsyncDeleteCourse(Guid courseId);
}