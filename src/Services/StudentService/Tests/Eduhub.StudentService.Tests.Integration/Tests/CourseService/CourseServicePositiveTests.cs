using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using CourseGenerator = Eduhub.StudentService.Infrastructure.IntegrationTests.Generators.CourseGenerator;
using EducatorGenerator = Eduhub.StudentService.Infrastructure.IntegrationTests.Generators.EducatorGenerator;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.CourseService;

/// <summary>
/// Позитивные тесты сервиса курса
/// </summary>
[Collection("DatabaseCollection")]
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
    public async Task Add_ReturnCreatedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = _courseGenerator.GenerateCourse(addedEducator.Id);

        // Act
        var action = await courseService.AddAsync(addedCourse, default);

        // Assert
        action.Should().NotBeNull();
        action.Should().BeEquivalentTo(addedCourse);
    }

    /// <summary>
    /// Проверка обновления курса
    /// </summary>
    [Fact]
    public async Task Update_ReturnUpdatedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);

        // Act
        var updatedCourse = await courseService.UpdateAsync(_courseGenerator.GenerateUpdateCourse(addedCourse.Id, addedEducator.Id), default);

        // Assert
        updatedCourse.Should().NotBeNull();
        updatedCourse.Id.Should().Be(addedCourse.Id);
        updatedCourse.Name.Should().Be(updatedCourse.Name);
        updatedCourse.Description.Should().Be(updatedCourse.Description);
        updatedCourse.EducatorId.Should().Be(updatedCourse.EducatorId);
    }

    /// <summary>
    /// Проверка получения всех существующих курсов
    /// </summary>
    [Fact]
    public async Task GetAll_ReturnAllCourses()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);

        // Act
        var courses = await courseService.GetAllAsync(default);

        // Assert
        courses.Should().NotBeNull();
    }

    /// <summary>
    /// Проверка выбор верного курса по идентификатору
    /// </summary>
    [Fact]
    public async Task GetById_ReturnSelectedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);

        // Act
        var selectedCourse = await courseService.GetByIdAsync(addedCourse.Id, default);

        // Assert
        selectedCourse.Should().NotBeNull();
        selectedCourse.Should().BeEquivalentTo(addedCourse);
    }

    /// <summary>
    /// Проверка удаления курса
    /// </summary>
    [Fact]
    public async Task Delete_ShouldDeleteCourseFromRepository()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);

        // Act
        await courseService.DeleteAsync(addedCourse.Id, CancellationToken.None);
        var deletedCourse = await courseRepository.GetByIdAsync(addedCourse.Id, default);

        // Assert
        deletedCourse.Should().BeNull();
    }
}