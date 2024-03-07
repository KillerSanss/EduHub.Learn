using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Tests.Unit.Infrastucture.Generators;

/// <summary>
/// Генерация преподавателя
/// </summary>
public static class EducatorGenerator
{
    private static readonly Faker<Educator> Faker = new Faker<Educator>()
        .CustomInstantiator(f => new Educator(
            f.Random.Guid(),
            new FullName(f.Name.LastName(), f.Name.FirstName(), f.Name.LastName()),
            Gender.Male,
            f.Random.Int(1),
            f.Date.Past(),
            new Phone(f.Phone.PhoneNumber("373########"))
        ));

    public static Educator GenerateEducator()
    {
        return Faker.Generate();
    }
}