namespace EduHub.StudentService.Application.Services.Dto;

public record CourseDto(
    Guid Id,
    string Name,
    string Description,
    Guid EducatorId);
