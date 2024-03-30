using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для зачисления
/// </summary>
public class EnrollmentMappingProfile : Profile
{
    public EnrollmentMappingProfile()
    {
        CreateMap<Enrollment, EnrollmentDto>()
            .ForMember(d => d.Id, o => o.MapFrom(e => e.Id))
            .ForMember(d => d.StudentId, o => o.MapFrom(e => e.StudentId))
            .ForMember(d => d.StartDate, o => o.MapFrom(e => e.StartDate))
            .ForMember(d => d.CourseId, o => o.MapFrom(e => e.CourseId));

        CreateMap<CreateEnrollmentDto, Enrollment>()
            .ConstructUsing(dto => new Enrollment(
                Guid.NewGuid(),
                dto.StudentId,
                dto.CourseId,
                dto.StartDate));

        CreateMap<Enrollment, StudentEnrollmentDto>()
            .ForMember(d => d.Id, o => o.MapFrom(e => e.Id))
            .ForMember(d => d.StartDate, o => o.MapFrom(e => e.StartDate))
            .ForMember(d => d.CourseId, o => o.MapFrom(e => e.CourseId))
            .ForMember(d => d.Name, o => o.MapFrom(e => e.Course.Name));
    }
}