using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
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
    public async Task Add_ReturnCreatedEducator()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = _educatorGenerator.GenerateEducator();

        // Act
        var action = await educatorService.AddAsync(addedEducator, default);

        // Assert
        action.Should().NotBeNull();
        action.FirstName.Should().Be(addedEducator.FirstName);
        action.Surname.Should().Be(addedEducator.Surname);
        action.Patronymic.Should().Be(addedEducator.Patronymic);
        action.Gender.Should().Be(addedEducator.Gender);
        action.Phone.Should().Be(new Phone(addedEducator.Phone).ToString());
        action.StartDate.Should().Be(addedEducator.StartDate);
        action.WorkExperience.Should().Be(addedEducator.WorkExperience);
    }

    /// <summary>
    /// Проверка обновления преподавателя
    /// </summary>
    [Fact]
    public async Task Update_ReturnUpdatedEducator()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        var newEducator = _educatorGenerator.GenerateUpdateEducator(addedEducator.Id);

        // Act
        var action = await educatorService.UpdateAsync(newEducator, default);

        // Assert
        action.Should().NotBeNull();
        action.Id.Should().Be(addedEducator.Id);
        action.FirstName.Should().Be(newEducator.FirstName);
        action.Surname.Should().Be(newEducator.Surname);
        action.Patronymic.Should().Be(newEducator.Patronymic);
        action.Gender.Should().Be(newEducator.Gender);
        action.Phone.Should().Be(new Phone(newEducator.Phone).ToString());
        action.StartDate.Should().Be(newEducator.StartDate);
        action.WorkExperience.Should().Be(newEducator.WorkExperience);
    }

    /// <summary>
    /// Проверка получения всех существующих преподавателей
    /// </summary>
    [Fact]
    public async Task GetAll_ReturnAllEducators()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        // Act
        var action = await educatorService.GetAllAsync(default);

        // Assert
        action.Should().NotBeNull();
    }

    /// <summary>
    /// Проверка выбор верного преподавателя по идентификатору
    /// </summary>
    [Fact]
    public async Task GetById_ReturnSelectedEducator()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);

        // Act
        var selectedEducator = await educatorService.GetByIdAsync(addedEducator.Id, default);

        // Assert
        selectedEducator.Id.Should().Be(addedEducator.Id);
        selectedEducator.FirstName.Should().Be(addedEducator.FirstName);
        selectedEducator.Surname.Should().Be(addedEducator.Surname);
        selectedEducator.Patronymic.Should().Be(addedEducator.Patronymic);
        selectedEducator.Gender.Should().Be(addedEducator.Gender);
        selectedEducator.Phone.Should().Be(addedEducator.Phone);
        selectedEducator.StartDate.Should().Be(addedEducator.StartDate);
        selectedEducator.WorkExperience.Should().Be(addedEducator.WorkExperience);
    }

    /// <summary>
    /// Проверка удаления преподавателя
    /// </summary>
    [Fact]
    public async Task Delete_ShouldDeleteStudent()
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