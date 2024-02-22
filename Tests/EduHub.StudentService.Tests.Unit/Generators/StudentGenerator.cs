using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация студента
/// </summary>
public class StudentGenerator
{
    private static readonly Faker<Student> StudentFaker = new Faker<Student>()
        .RuleFor(s => s.Id, f => f.Random.Guid())
        .RuleFor(s => s.FullName, f => new FullName(f.Name.LastName(), f.Name.FirstName(), f.Name.LastName()))
        .RuleFor(s => s.Gender, Gender.Male)
        .RuleFor(s => s.BirthDate, f => f.Date.Past(18))
        .RuleFor(s => s.Email, f => new Email(f.Internet.Email()))
        .RuleFor(s => s.Phone, f => new Phone(f.Phone.PhoneNumber("+373########")))
        .RuleFor(s => s.Address, f => new FullAddress(f.Address.City(), f.Address.StreetName(), f.Random.Int(1, 1000)))
        .RuleFor(s => s.Avatar, f => f.Image.PicsumUrl() + f.PickRandom(new[] {".jpeg", ".png"}));

    public static Student GenerateStudent()
    {
        return StudentFaker.Generate();
    }
}