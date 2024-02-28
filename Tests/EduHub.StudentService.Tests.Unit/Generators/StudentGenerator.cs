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
    private static readonly Faker _faker = new();

    public static Student GenerateStudent()
    {
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var birthDate = _faker.Date.Past();
        var email = new Email(_faker.Internet.Email());
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
        var address = new FullAddress(_faker.Address.City(), _faker.Address.StreetName(), _faker.Random.Int(1, 1000));
        var avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

        return new Student(id, fullName, gender, birthDate, email, phone, address, avatar);
    }
}