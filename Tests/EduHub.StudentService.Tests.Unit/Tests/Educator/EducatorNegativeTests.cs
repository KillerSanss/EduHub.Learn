using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Tests.Unit.Tests.Educator;

/// <summary>
/// Негативные unit тесты для сущности Educator
/// </summary>
public class EducatorNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается ArgumentException при пустом имени.
    /// </summary>
    [Theory]
    [InlineData(null)]
    public void Add_NullFullName_ThrowArgumentException(FullName fullName)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается GuardValidationException при неверном gender.
    /// </summary>
    [Theory]
    [InlineData(Gender.None)]
    public void Add_NoneGender_ThrowGuardValidationException(Gender gender)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается ArgumentException при неверном workExperience.
    /// </summary>
    [Theory]
    [InlineData(-1)]
    public void Add_NegativeWorkExperience_ThrowArgumentException(int workExperience)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается GuardValidationException при неверном startDate.
    /// </summary>
    [Theory]
    [InlineData("2069-01-01")]
    public void Add_FutureStartDate_ThrowGuardValidationException(DateTime startDate)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(1);
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}