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
    private static readonly Faker _faker = new();

    public static Educator GenerateEducator()
    {
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();

        return new Educator(id, fullName, gender, workExperience, startDate, phone);
    }
}