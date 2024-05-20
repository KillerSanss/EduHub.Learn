using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities.Enums;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

public class EducatorGenerator
{
    private readonly Faker _faker = new();

    public CreateEducatorDto GenerateEducator()
    {
        var educator = new CreateEducatorDto
        {
            FirstName = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            Patronymic = _faker.Name.LastName(),
            Gender = Gender.Male,
            Phone = _faker.Phone.PhoneNumber("373########"),
            StartDate = _faker.Date.Past(),
            WorkExperience = _faker.Random.Int(1)
        };

        return educator;
    }

    public UpdateEducatorDto GenerateUpdateEducator(Guid id)
    {
        var newEducator = new UpdateEducatorDto
        {
            Id = id,
            FirstName = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            Patronymic = _faker.Name.LastName(),
            Gender = Gender.Male,
            Phone = _faker.Phone.PhoneNumber("373########"),
            StartDate = _faker.Date.Past(),
            WorkExperience = _faker.Random.Int(1)
        };

        return newEducator;
    }
}