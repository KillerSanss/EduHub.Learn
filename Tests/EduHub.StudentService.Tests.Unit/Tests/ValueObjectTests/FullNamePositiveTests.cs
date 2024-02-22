using Bogus;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.ValueObjectTests;

/// <summary>
/// Позитивные unit тесты для FullName.
/// </summary>
public class FullNameTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что у FullName корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_FullNameInstance_ReturnFullName()
    {
        // Arrange
        var surname = _faker.Name.LastName();
        var firstName = _faker.Name.FirstName();
        var patronymic = _faker.Name.LastName();

        // Act
        var fullName = new FullName(surname, firstName, patronymic);

        // Assert
        fullName.Should().NotBeNull();
        fullName.FirstName.Should().Be(firstName);
        fullName.Surname.Should().Be(surname);
        fullName.Patronymic.Should().Be(patronymic);
    }
}