using Eduhub.StudentService.Domain.Entities;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

public class CourseGenerator
{
    private static readonly Faker<Course> CourseFaker = new Faker<Course>()
        .RuleFor(c => c.Id, f => f.Random.Guid())
        .RuleFor(c => c.Name, f => f.Random.String(1, 50))
        .RuleFor(c => c.Description, f => f.Random.String())
        .RuleFor(c => c.EducatorId, f => f.Random.Guid());

    public static Course GenerateCourse()
    {
        return CourseFaker.Generate();
    }
}