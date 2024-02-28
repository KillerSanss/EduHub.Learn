using Ardalis.GuardClauses;
using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.GuardTests;

/// <summary>
/// Позитивные unit тесты для кастомных гуардов
/// </summary>
public class GuardPositiveTests
{
    private readonly Faker _faker = new();

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
        // Arrange
        var gender = Gender.Male;
        
        // Act
        Action action = () => Guard.Against.Enum(gender);

        // Assert
        action.Should().NotThrow();
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
        var phoneNumber = _faker.Phone.PhoneNumber("373########");

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
        var avatarUrl = _faker.Image.PicsumUrl() + _faker.PickRandom(".jpeg", ".png");

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