using Bogus;
using Eduhub.StudentService.Domain.Entities;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация зачисления
/// </summary>
public static class EnrollmentGenerator
{
    private static readonly Faker Faker = new();

    public static Enrollment GenerateEnrollment()
    {
        var id = Faker.Random.Guid();
        var studentId = Faker.Random.Guid();
        var courseId = Faker.Random.Guid();
        var startDate = Faker.Date.Past();

        return new Enrollment(id, studentId, courseId, startDate);
    }
}