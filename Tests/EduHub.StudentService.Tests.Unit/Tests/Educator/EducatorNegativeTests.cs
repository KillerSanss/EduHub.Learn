using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Tests.Unit.Tests.EducatorTests;

/// <summary>
/// Негативные unit тесты для сущности Educator
/// </summary>
public class EducatorNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается ArgumentException при пустом имени.
    /// </summary>
    [Fact]
    public void Add_NullFullName_ThrowArgumentException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        FullName? fullName = null;
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается GuardValidationException при неверном gender.
    /// </summary>
    [Fact]
    public void Add_NoneGender_ThrowGuardValidationException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.None;
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается ArgumentException при неверном workExperience.
    /// </summary>
    [Fact]
    public void Add_NegativeWorkExperience_ThrowArgumentException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(-100, -1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается GuardValidationException при неверном startDate.
    /// </summary>
    [Fact]
    public void Add_FutureStartDate_ThrowGuardValidationException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Future();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}