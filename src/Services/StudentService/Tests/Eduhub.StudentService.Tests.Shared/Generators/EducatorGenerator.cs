using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace Eduhub.StudentService.Tests.Shared.Generators;

public class EducatorGenerator
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Генерация преподавателя
    /// </summary>
    /// <returns>Преподаватель.</returns>
    public CreateEducatorDto GenerateEducatorDto()
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
    public UpdateEducatorDto GenerateUpdateEducatorDto(Guid id)
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