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
            .ConstructUsing(c => new CourseDto(
                Guid.NewGuid(),
                c.Name,
                c.Description,
                c.EducatorId));

        CreateMap<Course, ResponseCourseDto>()
            .ConstructUsing(c => new ResponseCourseDto(
                Guid.NewGuid(),
                c.Name,
                c.Description));

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