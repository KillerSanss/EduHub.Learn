using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto;

public record EducatorDto(
    Guid Id,
    FullName FullName,
    Gender Gender,
    Phone Phone,
    int WorkExperience,
    DateTime StartDate);