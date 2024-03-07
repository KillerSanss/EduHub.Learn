using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities;
using EduHub.StudentService.Tests.Unit.Infrastucture.Generators;

namespace EduHub.StudentService.Tests.Unit.Tests.Courses;

/// <summary>
/// Позитивные unit тесты для сущности Course.
/// </summary>
public class CoursePositiveTests
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Проверка, что у сущности Course корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_Course_ReturnNewCourse()
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
    public void Update_Course_ReturnSameCourse()
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
            .Excluding(o => o.Id));
    }
}