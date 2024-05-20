using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Course;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

public class CourseGenerator
{
    private readonly Faker _faker = new();

    public CreateCourseDto GenerateCourse(Guid educatorId)
    {
        var course = new CreateCourseDto
        {
            Name = _faker.Random.Word(),
            Description = _faker.Random.Word(),
            EducatorId = educatorId
        };

        return course;
    }

    public UpdateCourseDto GenerateUpdateCourse(Guid id, Guid educatorId)
    {
        var newCourse = new UpdateCourseDto
        {
            Id = id,
            Name = _faker.Random.Word(),
            Description = _faker.Random.Word(),
            EducatorId = educatorId
        };

        return newCourse;
    }
}