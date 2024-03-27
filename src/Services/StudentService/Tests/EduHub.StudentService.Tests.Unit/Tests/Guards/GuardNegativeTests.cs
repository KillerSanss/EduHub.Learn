using Ardalis.GuardClauses;
using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Validations;
using Eduhub.StudentService.Domain.Validations.Enums;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using Eduhub.StudentService.Domain.Validations.GuardClasses;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.Guards;

/// <summary>
/// Негативные unit тесты для кастомных гуардов
/// </summary>
public class GuardNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что гуард DateGuard выбрасывает исключение GuardValidationException
    /// </summary>
    [Fact]
    public void DateGuard_ThrowGuardValidationException()
    {
        // Arrange
        var date = _faker.Date.Future();

        // Act
        Action action = () => Guard.Against.FutureDate(date);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что гуард EnumGuard выбрасывает исключение GuardValidationException
    /// </summary>
    [Fact]
    public void EnumGuard_ThrowGuardValidationException()
    {
        // Arrange
        var gender = default(Gender);

        // Act
        Action action = () => Guard.Against.Enum(gender, defaultValues: Gender.None);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что гуард StringGuard выбрасывает исключение GuardValidationException при валидации строк
    /// </summary>
    [Fact]
    public void StringGuard_ThrowGuardValidationException()
    {
        // Arrange
        var text = _faker.Random.String(10);

        // Act
        Action action1 = () => Guard.Against.String(text, 100, Operation.GreaterThanOrEqual);
        Action action2 = () => Guard.Against.String(text, 2, Operation.LessThanOrEqual);
        Action action3 = () => Guard.Against.String(text, 2, Operation.Equal);
        Action action4 = () => Guard.Against.String(text, 100, Operation.GreaterThan);
        Action action5 = () => Guard.Against.String(text, 2, Operation.LessThan);
        Action action6 = () => Guard.Against.String(text, 20, (Operation)100);

        // Assert
        action1.Should().Throw<GuardValidationException>();
        action2.Should().Throw<GuardValidationException>();
        action3.Should().Throw<GuardValidationException>();
        action4.Should().Throw<GuardValidationException>();
        action5.Should().Throw<GuardValidationException>();
        action6.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard выбрасывает исключение GuardValidationException при валидации электронной почты
    /// </summary>
    [Fact]
    public void RegexEmailGuard_ThrowGuardValidationException()
    {
        // Arrange
        var email = _faker.Random.String();

        // Act
        Action action = () => Guard.Against.Regex(email, RegexPatterns.EmailPattern, ErrorMessage.EmailFormat);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard выбрасывает исключение GuardValidationException при валидации телефона
    /// </summary>
    [Fact]
    public void RegexPhoneGuard_ThrowGuardValidationException()
    {
        // Assert
        var phone = _faker.Random.String();

        // Act
        Action action = () => Guard.Against.Regex(phone, RegexPatterns.PhonePattern, ErrorMessage.PhoneFormat);

        // Arrange
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard выбрасывает исключение GuardValidationException при валидации ссылки на аватар
    /// </summary>
    [Fact]
    public void RegexAvatarGuard_ThrowGuardValidationException()
    {
        // Assert
        var avatarUrl = _faker.Random.String();

        // Act
        Action action = () => Guard.Against.Regex(avatarUrl, RegexPatterns.AvatarUrlPattern, ErrorMessage.AvatarPattern);

        // Arrange
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что гуард RegexGuard выбрасывает исключение GuardValidationException при валидации текста
    /// </summary>
    [Fact]
    public void RegexLettersGuard_ThrowGuardValidationException()
    {
        // Arrange
        var text = _faker.Random.String() + "-";

        // Act
        Action action = () => Guard.Against.Regex(text, RegexPatterns.LettersPattern, ErrorMessage.OnlyLetters);

        // Arrange
        action.Should().Throw<GuardValidationException>();
    }
}