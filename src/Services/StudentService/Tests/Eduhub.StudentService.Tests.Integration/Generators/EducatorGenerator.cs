using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities.Enums;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

/// <summary>
/// Класс генерации преподавателя
/// </summary>
public class EducatorGenerator
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Генерация преподавателя
    /// </summary>
    /// <returns>Преподаватель.</returns>
    public CreateEducatorDto GenerateEducator()
    {
        var educator = new CreateEducatorDto
        {
            FirstName = _faker.Name.FirstName(),
            Surname = _faker.Name.LastName(),
            Patronymic = _faker.Name.LastName(),
            Gender = _faker.PickRandom(Gender.Female, Gender.Male),
            Phone = _faker.Phone.PhoneNumber("373########"),
            StartDate = _faker.Date.Past(),
            WorkExperience = _faker.Random.Int(1)
        };

        return educator;
    }

    /// <summary>
    /// Генeрация преподавателя на обновление
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <returns>Преподаватель.</returns>
    public UpdateEducatorDto GenerateUpdateEducator(Guid id)
    {
        var educator = new UpdateEducatorDto
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

        return educator;
    }
}