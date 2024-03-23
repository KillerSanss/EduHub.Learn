using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Course;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Mapping;

/// <summary>
/// Конфигурация маппинга для курса
/// </summary>
public class СourseMappingProfile : Profile
{
    public СourseMappingProfile()
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

        CreateMap<CreateCourseDto, Course>()
            .ConstructUsing(c => new Course(
                Guid.NewGuid(),
                c.Name,
                c.Description,
                c.EducatorId));

        CreateMap<Course, CreateCourseDto>()
            .ConstructUsing(dto => new CreateCourseDto(
                dto.Name,
                dto.Description,
                dto.EducatorId));

        CreateMap<UpdateCourseDto, Course>()
            .ConstructUsing(c => new Course(
                Guid.NewGuid(),
                c.Name,
                c.Description,
                c.EducatorId));

        CreateMap<Course, UpdateCourseDto>()
            .ConstructUsing(dto => new UpdateCourseDto(
                dto.Id,
                dto.Name,
                dto.Description,
                dto.EducatorId));
    }
}