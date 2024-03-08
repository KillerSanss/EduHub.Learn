using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Tests.Unit.Tests.Enrollments;

/// <summary>
/// Позитивные unit тесты для сущности Enrollment.
/// </summary>
public class EnrollmentPositiveTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Enrollment корректно создается экземпляр
    /// </summary>
    [Fact]
    public void Add_Enrollment_ReturnNewEnrollment()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var studentId = _faker.Random.Guid();
        var courseId = _faker.Random.Guid();
        var startDate = _faker.Date.Past();

        // Act
        var enrollment = new Enrollment(id, studentId, courseId, startDate);

        // Assert
        enrollment.Id.Should().Be(id);
        enrollment.StudentId.Should().Be(studentId);
        enrollment.CourseId.Should().Be(courseId);
        enrollment.StartDate.Should().Be(startDate);
    }
}