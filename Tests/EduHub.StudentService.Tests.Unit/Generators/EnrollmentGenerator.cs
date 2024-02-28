using Bogus;
using Eduhub.StudentService.Domain.Entities;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация зачисления
/// </summary>
public static class EnrollmentGenerator
{
    private static readonly Faker _faker = new();

    public static Enrollment GenerateEnrollment()
    {
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        return new Enrollment(id, studentId, courseId, startDate);
    }
}