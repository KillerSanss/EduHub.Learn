using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Repositories;

/// <summary>
/// Репозиторий зачисления
/// </summary>
public interface IEnrollmentRepository
{
    Task<Enrollment> GetEnrollmentById(Guid enrollmentId);
    Task<Enrollment> EnrollStudent(Guid studentId, Guid courseId, DateTime startDate);
    Task<List<Enrollment>> GetStudentEnrollments(Guid studentId);
    Task<List<Enrollment>> GetAllEnrollments();
    Task<Enrollment> DeleteEnrollment(Guid enrollmentId);
}