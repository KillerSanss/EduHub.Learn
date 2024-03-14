using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий EnrollmentService
/// </summary>
public interface IEnrollmentService
{
    Task<Enrollment> AsyncEnrollStudent(Guid studentId, Guid courseId, DateTime startDate);
    Task<List<Enrollment>> AsyncGetStudentEnrollments(Guid studentId);
    Task<List<Enrollment>> AsyncGetAllEnrollments();
    Task<Enrollment> AsyncDeleteEnrollment(Guid enrollmentId);
}