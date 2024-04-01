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
        CreateMap<Enrollment, EnrollmentDto>();

        CreateMap<CreateEnrollmentDto, Enrollment>()
            .ConstructUsing(dto => new Enrollment(
                Guid.NewGuid(),
                dto.StudentId,
                dto.CourseId,
                dto.StartDate));

        CreateMap<Enrollment, StudentEnrollmentDto>()
            .ForMember(d => d.Name, o => o.MapFrom(e => e.Course.Name));
    }
}