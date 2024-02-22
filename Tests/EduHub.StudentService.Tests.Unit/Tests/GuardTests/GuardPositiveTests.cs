using Ardalis.GuardClauses;
using Bogus;
using Bogus.DataSets;
using Eduhub.StudentService.Domain.Validations;
using Eduhub.StudentService.Domain.Validations.Enums;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.GuardTests;

/// <summary>
/// Позитивные unit тесты для кастомных гуардов
/// </summary>
public class GuardPositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что гуард DateGuard работает корректно
    /// </summary>
    [Fact]
    public void DateGuard_ReturnDate()
    {
        // Arrange
        var pastDate = _faker.Date.Past();

        // Act
        Action action = () => Guard.Against.FutureDate(pastDate);

        // Assert
        action.Should().NotThrow();
    }

    /// <summary>
    /// Проверка, что гуард EnumGuard работает корректно
    /// </summary>
    [Fact]
    public void EnumGuard_ReturnEnum()
    {
        // Act
        Action action = () => Guard.Against.Enum(Name.Gender.Male);

        // Assert
        action.Should().NotThrow();
    }

    /// <summary>
    /// Проверка, что гуард StringGuard работает корректно
    /// </summary>
    [Fact]
    public void StringGuard_ReturnString()
    {
        // Arrange
        var text = _faker.Random.String(10);

        // Act
        var value1 = Guard.Against.String(text, 2, Operation.GreaterThanOrEqual);
        var value2 = Guard.Against.String(text, 60, Operation.LessThanOrEqual);
        var value3 = Guard.Against.String(text, 10, Operation.Equal);
        var value4 = Guard.Against.String(text, 2, Operation.GreaterThan);
        var value5 = Guard.Against.String(text, 60, Operation.LessThan);

        // Assert
        value1.Should().Be(value1);
        value2.Should().Be(value2);
        value3.Should().Be(value3);
        value4.Should().Be(value4);
        value5.Should().Be(value5);
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard работает корректно при валидации электронной почты
    /// </summary>
    [Fact]
    public void RegexEmailGuard_ReturnEmail()
    {
        // Arrange
        var email = _faker.Internet.Email();

        // Act
        Action action = () => Guard.Against.Regex(email, RegexPatterns.EmailPattern, ErrorMessage.EmailFormat);

        // Assert
        action.Should().NotThrow();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard работает корректно при валидации телефона
    /// </summary>
    [Fact]
    public void RegexPhoneGuard_ReturnPhone()
    {
        // Arrange
        var phoneNumber = _faker.Phone.PhoneNumber("+373########");

        // Act
        Action action = () => Guard.Against.Regex(phoneNumber, RegexPatterns.PhonePattern, ErrorMessage.PhoneFormat);

        // Assert
        action.Should().NotThrow();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard работает корректно при ссылки на аватар
    /// </summary>
    [Fact]
    public void RegexAvatarGuard_ReturnAvatarUrl()
    {
        // Arrange
        var avatarUrl = _faker.Image.PicsumUrl() + _faker.PickRandom(new[] {".jpeg", ".png"});

        // Act
        Action action = () => Guard.Against.Regex(avatarUrl, RegexPatterns.AvatarUrlPattern, ErrorMessage.AvatarPattern);

        // Assert
        action.Should().NotThrow();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard работает корректно при валидации телефона
    /// </summary>
    [Fact]
    public void RegexLettersGuard_ReturnString()
    {
        // Arrange
        var text = _faker.Random.String2(1, 100, "a");

        // Act
        Action action = () => Guard.Against.Regex(text, RegexPatterns.LettersPattern, ErrorMessage.InvalidLength);

        // Assert
        action.Should().NotThrow();
    }
}