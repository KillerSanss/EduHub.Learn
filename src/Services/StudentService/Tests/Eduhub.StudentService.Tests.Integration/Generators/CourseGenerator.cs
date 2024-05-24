using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Course;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

/// <summary>
/// Класс генерации курса
/// </summary>
public class CourseGenerator
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Генерация курса
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <returns>Курс.</returns>
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

    /// <summary>
    /// Генерация курса для обновления
    /// </summary>
    /// <param name="id">Идентификатор курса на обновление.</param>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <returns>Курс.</returns>
    public UpdateCourseDto GenerateUpdateCourse(Guid id, Guid educatorId)
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
}