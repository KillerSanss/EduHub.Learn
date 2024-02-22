using Eduhub.StudentService.Domain.Validations.Exceptions.Enrollment;
using Eduhub.StudentService.Tests.Unit.Generators;
using FluentAssertions;

namespace EduHub.StudentService.Tests.Unit.Tests.StudentTests;

/// <summary>
/// Негативные unit тесты для сущности Student.
/// </summary>
public class StudentNegativeTests
{
    /// <summary>
    /// Проверка, что метод AddEnrollment сущности Student выбрасывает исключение EnrollmentConflictException.
    /// </summary>
    [Fact]
    public void AddEnrollment_ShouldThrowEnrollmentConflictException()
    {
        // Arrange
        var student = StudentGenerator.GenerateStudent();
        var enrollment = EnrollmentGenerator.GenerateEnrollment();

        // Act
        student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);
        Action action = () => student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);

        // Assert
        action.Should()
            .Throw<EnrollmentConflictException>();
    }

    /// <summary>
    /// Проверка, что метод DeleteEnrollment сущности Student выбрасывает исключение EnrollmentNotFoundException.
    /// </summary>
    [Fact]
    public void DeleteEnrollment_ShouldThrowEnrollmentNotFoundException()
    {
        // Arrange
        var student = StudentGenerator.GenerateStudent();
        var enrollment = EnrollmentGenerator.GenerateEnrollment();

        // Act
        student.AddEnrollment(enrollment.Id, enrollment.CourseId, enrollment.StartDate);
        Action action = () => student.DeleteEnrollment(Guid.NewGuid());

        // Assert
        action.Should()
            .Throw<EnrollmentNotFoundException>();
    }
}