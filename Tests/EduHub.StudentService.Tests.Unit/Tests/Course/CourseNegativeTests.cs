using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Tests.Unit.Tests.Course;

/// <summary>
/// Негативные unit тесты для сущности Course.
/// </summary>
public class CourseNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается ArgumentException при пустом названия курса.
    /// </summary>
    [Theory]
    [InlineData(null)]
    public void Add_NullName_ThrowArgumentException(string name)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var description = _faker.Random.String();
        var educatorId = _faker.Random.Guid();

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается GuardValidationException при слишком длинном названии курса.
    /// </summary>
    [Theory]
    [InlineData("111111111111111111111111111111111111111111111111111")]
    public void Add_TooLongName_ThrowGuardValidationException(string name)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var description = _faker.Random.String();
        var educatorId = _faker.Random.Guid();

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается ArgumentException при пустом educatorId.
    /// </summary>
    [Theory]
    [InlineData("00000000-0000-0000-0000-000000000000")]
    public void Add_EmptyEducatorId_ThrowGuardValidationException(string guid)
    {
        // Arrange
        var id = _faker.Random.Guid();
        var name = _faker.Random.String(10);
        var description = _faker.Random.String();

        // Act
        var action = () => new Eduhub.StudentService.Domain.Entities.Course(id, name, description, Guid.Parse(guid));

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}