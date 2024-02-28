using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Tests.Unit.Tests.EnrollmentTests;

/// <summary>
/// Негативные unit тесты для сущности Enrollment.
/// </summary>
public class EnrollmentNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается ArgumentException при пустом studentId.
    /// </summary>
    [Fact]
    public void Add_EmptyStudentId_ThrowArgumentException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        Guid studentId = default;
        var courseId = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        // Act
        var action = () => new Enrollment(id, studentId, courseId, startDate);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается ArgumentException при пустом courseId.
    /// </summary>
    [Fact]
    public void Add_EmptyCourseId_ThrowArgumentException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        Guid courseId = default;
        var startDate = _faker.Date.Past();

        // Act
        var action = () => new Enrollment(id, studentId, courseId, startDate);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается GuardValidationException при неверном startDate.
    /// </summary>
    [Fact]
    public void Add_EmptyCourseId_ThrowGuardValidationException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();
        var startDate = _faker.Date.Future();

        // Act
        var action = () => new Enrollment(id, studentId, courseId, startDate);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}