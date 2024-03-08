using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using EduHub.StudentService.Tests.Unit.Infrastructure.Data;

namespace EduHub.StudentService.Tests.Unit.Tests.Educators;

/// <summary>
/// Негативные unit тесты для сущности Educator
/// </summary>
public class EducatorNegativeTests
{
    private readonly Faker _faker = new();

    public static IEnumerable<object[]> TestEducatorArgumentExceptionData = TestData.GetEducatorArgumentExceptionProperties();
    public static IEnumerable<object[]> TestEducatorGuardValidationExceptionData = TestData.GetEducatorGuardValidationExceptionProperties();

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается ArgumentException.
    /// </summary>
    /// <param name="surname">Фамилия.</param>
    /// <param name="name">Имя.</param>
    /// <param name="patronymic">Отчество.</param>
    /// <param name="workExperience">Опыт работы.</param>
    [Theory]
    [MemberData(nameof(TestEducatorArgumentExceptionData))]
    public void Add_Properties_ThrowArgumentException(string surname, string name, string patronymic, int workExperience)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var gender = Gender.Male;
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Educator(id, new FullName(surname, name, patronymic), gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Educator выбрасывается GuardValidationException.
    /// </summary>
    /// <param name="gender">Гендер.</param>
    /// <param name="startDate">Начало работы.</param>
    [Theory]
    [MemberData(nameof(TestEducatorGuardValidationExceptionData))]
    public void Add_Properties_ThrowGuardValidationException(Gender gender, DateTime startDate)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var workExperience = _faker.Random.Int(1);
        var phone = new Phone(_faker.Phone.PhoneNumber("373########"));

        // Act
        var action = () => new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}