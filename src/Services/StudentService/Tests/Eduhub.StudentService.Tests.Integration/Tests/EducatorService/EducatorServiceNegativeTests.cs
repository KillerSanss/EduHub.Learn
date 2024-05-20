using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.EducatorService;

/// <summary>
/// Негативные тесты сервиса преподавателя
/// </summary>
[Collection("DatabaseCollection")]
public class EducatorServiceNegativeTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly EducatorGenerator _educatorGenerator = new();

    public EducatorServiceNegativeTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync сервиса преподавателя выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Delete_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        // Act
        var action = async () => await educatorService.DeleteAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Educator>>();
    }

    /// <summary>
    /// Проверка, что у метода GetByIdAsync сервиса преподавателя выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task GetById_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        // Act
        var action = async () => await educatorService.GetByIdAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Educator>>();
    }

    /// <summary>
    /// Проверка, что у метода UpdateAsync сервиса преподавателя выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Update_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        // Act
        var action = async () => await educatorService.UpdateAsync(_educatorGenerator.GenerateUpdateEducator(Guid.NewGuid()), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Educator>>();
    }
}