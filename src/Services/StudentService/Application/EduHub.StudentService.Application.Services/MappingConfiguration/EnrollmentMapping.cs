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
        CreateMap<Enrollment, EnrollmentRecord>()
            .ConstructUsing(e => new EnrollmentRecord(
                e.Id,
                e.StudentId,
                e.CourseId,
                e.StartDate));
    }
}