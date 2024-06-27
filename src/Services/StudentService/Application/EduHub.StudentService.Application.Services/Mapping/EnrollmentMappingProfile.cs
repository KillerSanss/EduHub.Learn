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

        CreateMap<Enrollment, EnrollmentOfStudentDto>()
            .ForMember(dest => dest.Name,
                opt => opt.MapFrom(e => e.Course.Name));
    }
}