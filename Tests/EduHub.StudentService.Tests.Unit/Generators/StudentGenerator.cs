using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация студента
/// </summary>
public static class StudentGenerator
{
    private static readonly Faker Faker = new();

    public static Student GenerateStudent()
    {
        var id = Faker.Random.Guid();
        var fullName = new FullName(Faker.Name.LastName(), Faker.Name.FirstName(), Faker.Name.LastName());
        var gender = Gender.Male;
        var birthDate = Faker.Date.Past();
        var email = new Email(Faker.Internet.Email());
        var phone = new Phone(Faker.Phone.PhoneNumber("373########"));
        var address = new FullAddress(Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 1000));
        var avatar = Faker.Image.PicsumUrl() + Faker.PickRandom(".jpeg", ".png");

        return new Student(id, fullName, gender, birthDate, email, phone, address, avatar);
    }
}