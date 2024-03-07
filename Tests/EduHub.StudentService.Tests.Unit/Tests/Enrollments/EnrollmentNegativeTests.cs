using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using Eduhub.StudentService.Domain.Entities;
using EduHub.StudentService.Tests.Unit.Infrastructure.Data;

namespace EduHub.StudentService.Tests.Unit.Tests.Enrollments;

/// <summary>
/// Негативные unit тесты для сущности Enrollment.
/// </summary>
public class EnrollmentNegativeTests
{
    private readonly Faker _faker = new();

    public static IEnumerable<object[]> TestEnrollmentArgumentExceptionData = TestData.GetEnrollmentArgumentExceptionProperties();

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается ArgumentException.
    /// </summary>
    /// <param name="studentId">Id студента.</param>
    /// <param name="courseId">Id курса.</param>
    [Theory]
    [MemberData(nameof(TestEnrollmentArgumentExceptionData))]
    public void Add_Properties_ThrowArgumentException(Guid studentId, Guid courseId)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        // Act
        var action = () => new Enrollment(id, studentId, courseId, startDate);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Enrollment выбрасывается GuardValidationException.
    /// </summary>
    [Theory]
    [InlineData("2060-01-01")]
    public void Add_FutureDate_ThrowGuardValidationException(DateTime startDate)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();

        // Act
        var action = () => new Enrollment(id, studentId, courseId, startDate);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}