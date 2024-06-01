using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.EducatorService;

/// <summary>
/// Позитивные тесты сервиса преподавателя
/// </summary>
[Collection("DatabaseCollection")]
public class EducatorServicePositiveTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly EducatorGenerator _educatorGenerator = new();

    public EducatorServicePositiveTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка верного создания преподавателя
    /// </summary>
    [Fact]
    public async Task Add_Educator_ReturnCreatedEducator()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = _educatorGenerator.GenerateEducator();

        // Act
        var action = await educatorService.AddAsync(addedEducator);

        // Assert
        action.Should().BeEquivalentTo(addedEducator);
    }

    /// <summary>
    /// Проверка обновления преподавателя
    /// </summary>
    [Fact]
    public async Task Update_Educator_ReturnUpdatedEducator()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());

        var newEducator = _educatorGenerator.GenerateUpdateEducator(addedEducator.Id);

        // Act
        var action = await educatorService.UpdateAsync(newEducator);

        // Assert
        action.Should().BeEquivalentTo(newEducator);
    }

    /// <summary>
    /// Проверка получения всех существующих преподавателей
    /// </summary>
    [Fact]
    public async Task GetAll_Educators_ReturnAllEducators()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());

        // Act
        var educators = await educatorService.GetAllAsync();

        // Assert
        educators.Should().ContainSingle(e => e.Id == addedEducator.Id);
    }

    /// <summary>
    /// Проверка выбор верного преподавателя по идентификатору
    /// </summary>
    [Fact]
    public async Task GetById_Educator_ReturnSelectedEducator()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());

        // Act
        var selectedEducator = await educatorService.GetByIdAsync(addedEducator.Id);

        // Assert
        selectedEducator.Should().BeEquivalentTo(addedEducator);
    }

    /// <summary>
    /// Проверка удаления преподавателя
    /// </summary>
    [Fact]
    public async Task Delete_Educator_ReturnNull()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());

        // Act
        await educatorService.DeleteAsync(addedEducator.Id);
        var action = await educatorRepository.GetByIdAsync(addedEducator.Id);

        // Assert
        action.Should().BeNull();
    }
}