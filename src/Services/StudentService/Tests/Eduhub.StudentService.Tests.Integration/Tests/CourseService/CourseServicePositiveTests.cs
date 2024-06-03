using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Tests.Shared.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.CourseService;

/// <summary>
/// Позитивные тесты сервиса курса
/// </summary>
[Collection(nameof(IntegrationTestCollection))]
public class CourseServicePositiveTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly EducatorGenerator _educatorGenerator = new();
    private readonly CourseGenerator _courseGenerator = new();

    public CourseServicePositiveTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка верного создания курса
    /// </summary>
    [Fact]
    public async Task Add_Course_ReturnCreatedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducatorDto());
        var addedCourse = _courseGenerator.GenerateCourseDto(addedEducator.Id);

        // Act
        var action = await courseService.AddAsync(addedCourse);

        // Assert
        action.Should().BeEquivalentTo(addedCourse);
    }

    /// <summary>
    /// Проверка обновления курса
    /// </summary>
    [Fact]
    public async Task Update_Course_ReturnUpdatedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducatorDto());
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourseDto(addedEducator.Id));

        var updateCourseData = _courseGenerator.GenerateUpdateCourseDto(addedCourse.Id, addedEducator.Id);

        // Act
        var course = await courseService.UpdateAsync(updateCourseData);

        // Assert
        course.Should().BeEquivalentTo(updateCourseData);
    }

    /// <summary>
    /// Проверка получения всех существующих курсов
    /// </summary>
    [Fact]
    public async Task GetAll_Courses_ReturnAllCourses()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducatorDto());

        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourseDto(addedEducator.Id));

        // Act
        var courses = await courseService.GetAllAsync();

        // Assert
        courses.Should().ContainSingle(e => e.Id == addedCourse.Id);
    }

    /// <summary>
    /// Проверка выбор верного курса по идентификатору
    /// </summary>
    [Fact]
    public async Task GetById_Course_ReturnSelectedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducatorDto());

        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourseDto(addedEducator.Id));

        // Act
        var selectedCourse = await courseService.GetByIdAsync(addedCourse.Id);

        // Assert
        selectedCourse.Should().BeEquivalentTo(addedCourse);
    }

    /// <summary>
    /// Проверка удаления курса
    /// </summary>
    [Fact]
    public async Task Delete_Course_ReturnNull()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducatorDto());
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourseDto(addedEducator.Id));

        // Act
        await courseService.DeleteAsync(addedCourse.Id, CancellationToken.None);
        var deletedCourse = await courseRepository.GetByIdAsync(addedCourse.Id);

        // Assert
        deletedCourse.Should().BeNull();
    }
}