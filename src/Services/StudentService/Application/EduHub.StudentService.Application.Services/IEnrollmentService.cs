using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий EnrollmentService
/// </summary>
public interface IEnrollmentService
{
    Task<EnrollmentDto> AsyncEnrollStudent(Guid studentId, Guid courseId, DateTime startDate);
    Task<List<EnrollmentDto>> AsyncGetStudentEnrollments(Guid studentId);
    Task<List<EnrollmentDto>> AsyncGetAllEnrollments();
    Task AsyncDeleteEnrollment(Guid enrollmentId);
}