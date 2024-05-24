using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
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
        var action = await educatorService.AddAsync(addedEducator, default);

        // Assert
        action.Should().BeEquivalentTo(addedEducator, options => options
            .Excluding(s => s.Phone));

        action.Phone.Should().Be(new Phone(addedEducator.Phone).ToString());
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

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        var newEducator = _educatorGenerator.GenerateUpdateEducator(addedEducator.Id);

        // Act
        var action = await educatorService.UpdateAsync(newEducator, default);

        // Assert
        action.Should().BeEquivalentTo(newEducator, options => options
            .Excluding(s => s.Phone));

        action.Phone.Should().Be(new Phone(newEducator.Phone).ToString());
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

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        // Act
        var educators = await educatorService.GetAllAsync(default);

        // Assert
        educators.Should().NotBeEmpty();
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

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        // Act
        var selectedEducator = await educatorService.GetByIdAsync(addedEducator.Id, default);

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

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        // Act
        await educatorService.DeleteAsync(addedEducator.Id, default);
        var action = await educatorRepository.GetByIdAsync(addedEducator.Id, default);

        // Assert
        action.Should().BeNull();
    }
}