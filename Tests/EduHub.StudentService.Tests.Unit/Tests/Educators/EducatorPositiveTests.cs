using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using EduHub.StudentService.Tests.Unit.Infrastucture.Generators;

namespace EduHub.StudentService.Tests.Unit.Tests.Educators;

/// <summary>
/// Позитивные unit тесты для сущности Educator.
/// </summary>
public class EducatorPositiveTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Educator корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_Educator_ReturnNewEducator()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var educator = new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        educator.Should().NotBeNull();
        educator.Id.Should().Be(id);
        educator.FullName.Should().Be(fullName);
        educator.Gender.Should().Be(gender);
        educator.WorkExperience.Should().Be(workExperience);
        educator.StartDate.Should().Be(startDate);
        educator.Phone.Should().Be(phone);
    }

    /// <summary>
    /// Проверка, что метод Update обновляет экземпляр сущности Educator.
    /// </summary>
    [Fact]
    public void Update_Educator_ReturnSameEducator()
    {
        // Arrange
        var educator = EducatorGenerator.GenerateEducator();
        var newEducator = EducatorGenerator.GenerateEducator();

        // Act
        educator.Update(newEducator.FullName,
            newEducator.Gender,
            newEducator.WorkExperience,
            newEducator.StartDate,
            newEducator.Phone);

        // Assert
        educator.Should().BeEquivalentTo(newEducator, options => options
            .Excluding(o => o.Id));
    }
}