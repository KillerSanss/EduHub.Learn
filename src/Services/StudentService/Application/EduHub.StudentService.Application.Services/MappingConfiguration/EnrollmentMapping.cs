using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.MappingConfiguration;

/// <summary>
/// Конфигурация маппинга для зачисления
/// </summary>
public class EnrollmentMapping : Profile
{
    public EnrollmentMapping()
    {
        CreateMap<Enrollment, EnrollmentDto>()
            .ConstructUsing(e => new EnrollmentDto(
                Guid.NewGuid(),
                e.StudentId,
                e.CourseId,
                e.StartDate));
    }
}