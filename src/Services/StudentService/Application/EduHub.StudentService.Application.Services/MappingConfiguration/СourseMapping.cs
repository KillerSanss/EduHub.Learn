using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.MappingConfiguration;

/// <summary>
/// Конфигурация маппинга для курса
/// </summary>
public class СourseMapping : Profile
{
    public СourseMapping()
    {
        CreateMap<Course, CourseDto>()
            .ConstructUsing(c => new CourseDto(
                Guid.NewGuid(),
                c.Name,
                c.Description,
                c.EducatorId));
    }
}