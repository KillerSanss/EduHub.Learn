using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Course;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для курса
/// </summary>
public class CourseMappingProfile : Profile
{
    public CourseMappingProfile()
    {
        CreateMap<Course, CourseDto>()
            .ForMember(d => d.Id, o => o.MapFrom(c => c.Id))
            .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
            .ForMember(d => d.Description, o => o.MapFrom(c => c.Description))
            .ForMember(d => d.EducatorId, o => o.MapFrom(c => c.EducatorId));

        CreateMap<Course, EducatorCourseDto>()
            .ForMember(d => d.Id, o => o.MapFrom(c => c.Id))
            .ForMember(d => d.Name, o => o.MapFrom(c => c.Name))
            .ForMember(d => d.Description, o => o.MapFrom(c => c.Description));

        CreateMap<CreateCourseDto, Course>()
            .ConstructUsing(c => new Course(
                Guid.NewGuid(),
                c.Name,
                c.Description,
                c.EducatorId));

        CreateMap<UpdateCourseDto, Course>()
            .ConstructUsing(c => new Course(
                Guid.NewGuid(),
                c.Name,
                c.Description,
                c.EducatorId));
    }
}