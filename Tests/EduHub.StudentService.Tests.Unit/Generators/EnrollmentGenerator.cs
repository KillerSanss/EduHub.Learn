using Bogus;
using Eduhub.StudentService.Domain.Entities;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация зачисления
/// </summary>
public class EnrollmentGenerator
{
    private static readonly Faker<Enrollment> EnrollmentFaker = new Faker<Enrollment>()
        .RuleFor(e => e.Id, f => f.Random.Guid())
        .RuleFor(e => e.CourseId, f => f.Random.Guid())
        .RuleFor(e => e.StartDate, f => f.Date.Past(18));

    public static Enrollment GenerateEnrollment()
    {
        return EnrollmentFaker.Generate();
    }
}