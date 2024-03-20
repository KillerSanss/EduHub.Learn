namespace EduHub.StudentService.Application.Services.Dto;

public record CourseRecord(
    Guid CourseId,
    string Name,
    string Description,
    Guid EducatorId);