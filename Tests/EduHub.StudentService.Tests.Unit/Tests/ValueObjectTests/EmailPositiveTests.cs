using Bogus;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.ValueObjectTests;

/// <summary>
/// Позитивные unit тесты для Email.
/// </summary>
public class EmailPositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что у Email корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_EmailInstance_ReturnEmail()
    {
        // Arrange
        var email = _faker.Internet.Email();

        // Act
        var userEmail = new Email(email);

        // Assert
        userEmail.Should().NotBeNull();
        userEmail.Value.Should().Be(email);
    }
}