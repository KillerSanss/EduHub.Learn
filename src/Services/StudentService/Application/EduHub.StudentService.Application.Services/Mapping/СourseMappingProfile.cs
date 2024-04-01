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
        CreateMap<Course, CourseDto>();

        CreateMap<Course, EducatorCourseDto>();

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