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
            .ConstructUsing(e => new EnrollmentDto(
                Guid.NewGuid(),
                e.StudentId,
                e.CourseId,
                e.StartDate));

        CreateMap<EnrollmentDto, Enrollment>()
            .ConstructUsing(dto => new Enrollment(
                Guid.NewGuid(),
                dto.StudentId,
                dto.CourseId,
                dto.StartDate));

        CreateMap<Enrollment, CreateEnrollmentDto>()
            .ConstructUsing(e => new CreateEnrollmentDto(
                Guid.NewGuid(),
                e.StudentId,
                e.CourseId,
                e.StartDate));

        CreateMap<CreateEnrollmentDto, Enrollment>()
            .ConstructUsing(dto => new Enrollment(
                Guid.NewGuid(),
                dto.StudentId,
                dto.CourseId,
                dto.StartDate));
    }
}