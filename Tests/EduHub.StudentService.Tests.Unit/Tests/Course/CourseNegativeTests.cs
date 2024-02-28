using FluentAssertions;
using Eduhub.StudentService.Domain.Entities;
using Bogus;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Tests.Unit.Tests.CourseTests;

/// <summary>
/// Негативные unit тесты для сущности Course.
/// </summary>
public class CourseNegativeTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается ArgumentException при пустом названия курса.
    /// </summary>
    [Fact]
    public void Add_NullName_ThrowArgumentException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        string? name = null;
        var description = _faker.Random.String();
        var educatorId = Guid.NewGuid();

        // Act
        var action = () => new Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается GuardValidationException при слишком длинном названии курса.
    /// </summary>
    [Fact]
    public void Add_TooLongName_ThrowGuardValidationException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var name = _faker.Random.String(51);
        var description = _faker.Random.String();
        var educatorId = Guid.NewGuid();

        // Act
        var action = () => new Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<GuardValidationException>();
    }

    /// <summary>
    /// Проверка, что у сущности Course выбрасывается ArgumentException при пустом educatorId.
    /// </summary>
    [Fact]
    public void Add_EmptyEducatorId_ThrowGuardValidationException()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var name = _faker.Random.String(10);
        var description = _faker.Random.String();
        Guid educatorId = default;

        // Act
        var action = () => new Course(id, name, description, educatorId);

        // Assert
        action.Should().Throw<ArgumentException>();
    }
}