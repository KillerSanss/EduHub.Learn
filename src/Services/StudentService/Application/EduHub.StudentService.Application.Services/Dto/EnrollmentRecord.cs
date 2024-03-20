namespace EduHub.StudentService.Application.Services.Dto;

public record EnrollmentRecord(
    Guid EnrollmentId,
    Guid StudentId,
    Guid CourseId,
    DateTime StartDate);