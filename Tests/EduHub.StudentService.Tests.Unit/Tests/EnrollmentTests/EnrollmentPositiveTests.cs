using Eduhub.StudentService.Domain.Entities;
using FluentAssertions;
using Bogus;

namespace EduHub.StudentService.Tests.Unit.Tests.EnrollmentTests;

/// <summary>
/// Позитивные unit тесты для сущности Enrollment.
/// </summary>
public class EnrollmentPositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что метод Update обновляет экземпляр сущности Educator.
    /// </summary>
    [Fact]
    public void Add_EnrollmentInstance_ReturnCorrectId()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        // Act
        var enrollment = new Enrollment(id, studentId, courseId, startDate);

        // Assert
        enrollment.StudentId.Should().Be(studentId);
    }
}