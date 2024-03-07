using Bogus;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Tests.Unit.Infrastucture.Generators;

/// <summary>
/// Генерация курса
/// </summary>
public static class CourseGenerator
{
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