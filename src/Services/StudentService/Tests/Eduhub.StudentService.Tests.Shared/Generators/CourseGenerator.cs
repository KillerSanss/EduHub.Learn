using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Course;
using Eduhub.StudentService.Domain.Entities;

namespace Eduhub.StudentService.Tests.Shared.Generators;

public class CourseGenerator
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Генерация курса
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <returns>Курс.</returns>
    public CreateCourseDto GenerateCourseDto(Guid educatorId)
    {
        var course = new CreateCourseDto
        {
            Name = _faker.Random.Word(),
            Description = _faker.Random.Word(),
            EducatorId = educatorId
        };
        
        return course;
    }
    
    /// <summary>
    /// Генерация курса для обновления
    /// </summary>
    /// <param name="id">Идентификатор курса на обновление.</param>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <returns>Курс.</returns>
    public UpdateCourseDto GenerateUpdateCourseDto(Guid id, Guid educatorId)
    {
        var course = new UpdateCourseDto
        {
            Id = id,
            Name = _faker.Random.Word(),
            Description = _faker.Random.Word(),
            EducatorId = educatorId
        };
        
        return course;
    }
    
    private static readonly Faker<Course> Faker = new Faker<Course>()
        .CustomInstantiator(f => new Course(
            f.Random.Guid(),
            f.Random.String(1, 50),
            f.Random.String(),
            f.Random.Guid()
        ));
    
    public static Course GenerateCourse()
    {
        return Faker.Generate();
    }
}