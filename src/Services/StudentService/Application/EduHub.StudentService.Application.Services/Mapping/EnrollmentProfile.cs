using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для зачисления
/// </summary>
public class EnrollmentProfile : Profile
{
    public EnrollmentProfile()
    {
        CreateMap<Enrollment, EnrollmentDto>()
            .ConstructUsing(e => new EnrollmentDto(
                e.StudentId,
                e.CourseId,
                e.StartDate));

        CreateMap<EnrollmentDto, Enrollment>()
            .ConstructUsing(dto => new Enrollment(
                Guid.NewGuid(),
                dto.StudentId,
                dto.CourseId,
                dto.StartDate));
    }
}