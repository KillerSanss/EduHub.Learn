using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Application.Services.Dto;

public record StudentRecord(
    Guid StudentId,
    FullName FullName,
    Gender Gender,
    DateTime BirthDate,
    Email Email,
    FullAddress Address,
    string Avatar);