using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий курса
/// </summary>
public interface ICourseRepository
{
    Task<Course> GetCourseById(Guid courseId);
    Task<Course> AddCourse(Course course);
    Task<Course> UpdateCourse(Course course);
    Task<Course> DeleteCourse(Guid courseId);
    Task<List<Course>> GetAllCourses();
}