using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Student;
using Eduhub.StudentService.Domain.Entities.Enums;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

public class StudentGenerator
{
    private readonly Faker _faker = new();

    public CreateStudentDto GenerateStudent()
    {
        var student = new CreateStudentDto
        {
            FirstName = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            Patronymic = _faker.Name.LastName(),
            BirthDate = _faker.Date.Past(),
            Gender = Gender.Male,
            Phone = _faker.Phone.PhoneNumber("373########"),
            Email = _faker.Internet.Email(),
            City = _faker.Address.City(),
            Street = _faker.Address.StreetName(),
            HouseNumber = _faker.Random.Int(1, 1000),
            Avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png")
        };

        return student;
    }

    public UpdateStudentDto GenerateUpdateStudent(Guid id)
    {
        var newStudent = new UpdateStudentDto
        {
            Id = id,
            FirstName = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            Patronymic = _faker.Name.LastName(),
            BirthDate = _faker.Date.Past(),
            Gender = Gender.Male,
            Phone = _faker.Phone.PhoneNumber("373########"),
            Email = _faker.Internet.Email(),
            City = _faker.Address.City(),
            Street = _faker.Address.StreetName(),
            HouseNumber = _faker.Random.Int(1, 1000),
            Avatar = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png")
        };

        return newStudent;
    }
}