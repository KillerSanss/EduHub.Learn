using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация преподавателя
/// </summary>
public class EducatorGenerator
{
    private static readonly Faker<Educator> EducatorFaker = new Faker<Educator>()
        .RuleFor(e => e.Id, f => f.Random.Guid())
        .RuleFor(e => e.FullName, f => new FullName(f.Name.LastName(), f.Name.FirstName(), f.Name.LastName()))
        .RuleFor(e => e.Gender, Gender.Male)
        .RuleFor(e => e.Phone, f => new Phone(f.Phone.PhoneNumber("+373########")))
        .RuleFor(e => e.WorkExperience, f => f.Random.Int(1))
        .RuleFor(e => e.StartDate, f => f.Date.Past());

    public static Educator GenerateEducator()
    {
        return EducatorFaker.Generate();
    }
}