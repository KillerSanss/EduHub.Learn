using Eduhub.StudentService.Tests.Unit.Generators;
using FluentAssertions;
using Eduhub.StudentService.Domain.Entities;
using Bogus;

namespace EduHub.StudentService.Tests.Unit.Tests.CourseTests;

/// <summary>
/// Позитивные unit тесты для сущности Course.
/// </summary>
public class CoursePositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что у сущности Course корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_CourseInstance_ReturnCourse()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var name = _faker.Random.String(2);
        var description = _faker.Random.String();
        var educatorId = Guid.NewGuid();

        // Act
        var course = new Course(id, name, description, educatorId);

        // Assert
        course.Should().NotBeNull();
        course.Id.Should().Be(id);
        course.Name.Should().Be(name);
        course.Description.Should().Be(description);
        course.EducatorId.Should().Be(educatorId);
    }

    /// <summary>
    /// Проверка, что метод Update обновляет экземпляр сущности Course.
    /// </summary>
    [Fact]
    public void Update_CourseInstance_UpdatedCourse()
    {
        // Arrange
        var course = CourseGenerator.GenerateCourse();
        var newCourse = CourseGenerator.GenerateCourse();

        // Act
        course.Update(newCourse.Name,
            newCourse.Description,
            newCourse.EducatorId);

        // Assert
        course.Should().BeEquivalentTo(newCourse, options => options
            .Excluding(o => o.Id)
            .ExcludingNestedObjects());
    }
}