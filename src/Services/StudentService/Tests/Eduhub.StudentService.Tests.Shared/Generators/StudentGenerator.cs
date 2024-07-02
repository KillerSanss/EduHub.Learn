using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Student;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace Eduhub.StudentService.Tests.Shared.Generators;

public class StudentGenerator
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Генерация студента
    /// </summary>
    /// <returns>Студент.</returns>
    public UpsertStudentDto GenerateUpsertStudentDto()
    {
        var student = new UpsertStudentDto
        {
            FirstName = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            Patronymic = _faker.Name.LastName(),
            BirthDate = _faker.Date.Past(),
            Gender = _faker.PickRandom(Gender.Female, Gender.Male),
            Phone = _faker.Phone.PhoneNumber("373########"),
            Email = _faker.Internet.Email(),
            City = _faker.Address.City(),
            Street = _faker.Address.StreetName(),
            HouseNumber = _faker.Random.Int(1, 1000),
            Avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png")
        };
        
        return student;
    }
    
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