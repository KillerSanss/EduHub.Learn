using Bogus;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Tests.Unit.Infrastucture.Generators;

/// <summary>
/// Генерация зачисления
/// </summary>
public static class EnrollmentGenerator
{
    private static readonly Faker<Enrollment> Faker = new Faker<Enrollment>()
        .CustomInstantiator(f => new Enrollment(
            f.Random.Guid(),
            f.Random.Guid(),
            f.Random.Guid(),
            f.Date.Past()
        ));

    public static Enrollment GenerateEnrollment()
    {
        return Faker.Generate();
    }
}