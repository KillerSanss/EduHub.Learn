using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.CourseService;

/// <summary>
/// Негативные тесты сервиса курса
/// </summary>
[Collection("DatabaseCollection")]
public class CourseServiceNegativeTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly EducatorGenerator _educatorGenerator = new();
    private readonly CourseGenerator _courseGenerator = new();

    public CourseServiceNegativeTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync сервиса курса выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Delete_Course_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        // Act
        var action = async () => await courseService.DeleteAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }

    /// <summary>
    /// Проверка, что у метода GetByIdAsync сервиса курса выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task GetById_Course_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        // Act
        var action = async () => await courseService.GetByIdAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }

    /// <summary>
    /// Проверка, что у метода UpdateAsync сервиса курса выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Update_Course_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        // Act
        var action = async () => await courseService.UpdateAsync(_courseGenerator.GenerateUpdateCourse(Guid.NewGuid(), addedEducator.Id), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }
    
    /// <summary>
    /// Создания курса с несуществующим преподавателем
    /// </summary>
    [Fact]
    public async Task Add_Course_ThrowDbUpdateException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        
        // Act
        var action = async () => await courseService.AddAsync(_courseGenerator.GenerateCourse(Guid.NewGuid()), default);
        
        // Assert
        await action.Should().ThrowAsync<DbUpdateException>();
    }
}