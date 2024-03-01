using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Tests.Unit.Tests.Enrollment;

/// <summary>
/// Негативные unit тесты для сущности Enrollment.
/// </summary>
public class EnrollmentNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается ArgumentException при пустом studentId.
    /// </summary>
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void Add_EmptyStudentId_ThrowArgumentException(string guid)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Enrollment(id, Guid.Parse(guid), courseId, startDate);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается ArgumentException при пустом courseId.
    /// </summary>
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void Add_EmptyCourseId_ThrowArgumentException(string guid)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Enrollment(id, studentId, Guid.Parse(guid), startDate);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается GuardValidationException при неверном startDate.
    /// </summary>
    [Theory]
    [InlineData("2069-01-01")]
    public void Add_FutureDate_ThrowGuardValidationException(DateTime startDate)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Enrollment(id, studentId, courseId, startDate);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}