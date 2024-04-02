using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Validations.Exceptions;
using FluentAssertions;
using EduHub.StudentService.Tests.Unit.Infrastructure.Data;

namespace EduHub.StudentService.Tests.Unit.Tests.Courses;

/// <summary>
/// Негативные unit тесты для сущности Course.
/// </summary>
public class CourseNegativeTests
{
    private readonly Faker _faker = new();

    public static IEnumerable<object[]> TestCourseArgumentExceptionData = TestData.GetCourseArgumentExceptionProperties();

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается ArgumentException.
    /// </summary>
    /// <param name="name">Название курса.</param>
    /// <param name="educatorId">Id преподавателя.</param>
    [Theory]
    [MemberData(nameof(TestCourseArgumentExceptionData))]
    public void Add_Properties_ThrowArgumentException(string name, Guid educatorId)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var description = _faker.Random.String();

        // Act
        var action = () => new Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается GuardValidationException.
    /// </summary>
    [Fact]
    public void Add_TooLongName_ThrowGuardValidationException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var name = _faker.Random.String(51);
        var description = _faker.Random.String();
        var educatorId = _faker.Random.Guid();

        // Act
        var action = () => new Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }
}