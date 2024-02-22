using Bogus;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.ValueObjectTests;

/// <summary>
/// Позитивные unit тесты для FullAddress.
/// </summary>
public class FullAddressPositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что у FullAddress корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_FullAddressInstance_ReturnFullAddress()
    {
        // Arrange
        var city = _faker.Address.City();
        var street = _faker.Address.StreetName();
        var houseNumber = _faker.Random.Int(1, 100);

        // Act
        var fullAddress = new FullAddress(city, street, houseNumber);

        // Assert
        fullAddress.Should().NotBeNull();
        fullAddress.City.Should().Be(city);
        fullAddress.Street.Should().Be(street);
        fullAddress.HouseNumber.Should().Be(houseNumber);
    }
}