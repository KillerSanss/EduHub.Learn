using Bogus;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.ValueObjectTests;

/// <summary>
/// Позитивные unit тесты для Phone.
/// </summary>
public class PhonePositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что у Phone корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_PhoneInstance_ReturnPhone()
    {
        // Arrange
        var phone = _faker.Phone.PhoneNumber("#+373########");

        // Act
        var phoneNumber = new Phone(phone);

        // Assert
        phoneNumber.Should().NotBeNull();
        phoneNumber.Value.Should().Be(phone);
    }
}