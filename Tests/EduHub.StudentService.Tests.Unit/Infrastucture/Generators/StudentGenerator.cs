using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Tests.Unit.Infrastucture.Generators;

/// <summary>
/// Генерация студента
/// </summary>
public static class StudentGenerator
{
    private static readonly Faker<Student> Faker = new Faker<Student>()
        .CustomInstantiator(f => new Student(
            f.Random.Guid(),
            new FullName(f.Name.LastName(), f.Name.FirstName(), f.Name.LastName()),
            Gender.Male,
            f.Date.Past(),
            new Email(f.Internet.Email()),
            new Phone(f.Phone.PhoneNumber("373########")),
            new FullAddress(f.Address.City(), f.Address.StreetName(), f.Random.Int(1, 1000)),
            f.Image.PicsumUrl() + f.PickRandom(".jpeg", ".png")
        ));

    public static Student GenerateStudent()
    {
        return Faker.Generate();
    }
}