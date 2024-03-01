using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Bogus;

namespace Eduhub.StudentService.Tests.Unit.Generators;

/// <summary>
/// Генерация преподавателя
/// </summary>
public static class EducatorGenerator
{
    private static readonly Faker Faker = new();

    public static Educator GenerateEducator()
    {
        var id = Faker.Random.Guid();
        var fullName = new FullName(Faker.Name.LastName(), Faker.Name.FirstName(), Faker.Name.LastName());
        var gender = Gender.Male;
        var phone = new Phone(Faker.Phone.PhoneNumber("373########"));
        var workExperience = Faker.Random.Int(1);
        var startDate = Faker.Date.Past();

        return new Educator(id, fullName, gender, workExperience, startDate, phone);
    }
}