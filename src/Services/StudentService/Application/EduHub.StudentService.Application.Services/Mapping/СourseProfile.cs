using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для курса
/// </summary>
public class СourseProfile : Profile
{
    public СourseProfile()
    {
        CreateMap<Course, CourseDto>()
            .ConstructUsing(c => new CourseDto(
                c.Name,
                c.Description,
                c.EducatorId));

        CreateMap<CourseDto, Course>()
            .ConstructUsing(dto => new Course(
                Guid.NewGuid(),
                dto.Name,
                dto.Description,
                dto.EducatorId));
    }
}