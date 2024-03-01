using Eduhub.StudentService.Domain.Entities;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

public static class CourseGenerator
{
    private static readonly Faker Faker = new();

    public static Course GenerateCourse()
    {
        var id = Faker.Random.Guid();
        var name = Faker.Random.String(1, 50);
        var description = Faker.Random.String();
        var educatorId = Faker.Random.Guid();

        return new Course(id, name, description, educatorId);
    }
}