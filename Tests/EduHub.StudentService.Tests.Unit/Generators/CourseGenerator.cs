using Eduhub.StudentService.Domain.Entities;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

public static class CourseGenerator
{
    private static readonly Faker _faker = new();

    public static Course GenerateCourse()
    {
        var id = _faker.Random.Guid();
        var name = _faker.Random.String(1, 50);
        var description = _faker.Random.String();
        var educatorId = _faker.Random.Guid();

        return new Course(id, name, description, educatorId);
    }
}