namespace EduHub.StudentService.Application.Services.Dto;

public record EnrollmentDto(
    Guid Id,
    Guid StudentId,
    Guid CourseId,
    DateTime StartDate);