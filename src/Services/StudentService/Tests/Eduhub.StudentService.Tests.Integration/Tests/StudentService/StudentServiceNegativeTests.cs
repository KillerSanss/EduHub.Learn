using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.StudentService;

/// <summary>
/// Негативные тесты сервиса студента
/// </summary>
[Collection("DatabaseCollection")]
public class StudentServiceNegativeTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly StudentGenerator _studentGenerator = new();

    public StudentServiceNegativeTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync сервиса студента выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Delete_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        // Act
        var action = async () => await studentService.DeleteAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }

    /// <summary>
    /// Проверка, что у метода GetByIdAsync сервиса студента выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task GetById_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        // Act
        var action = async () => await studentService.GetByIdAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }

    /// <summary>
    /// Проверка, что у метода UpdateAsync сервиса студента выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Update_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        // Act
        var action = async () => await studentService.UpdateAsync(_studentGenerator.GenerateUpdateStudent(Guid.NewGuid()), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Student>>();
    }
}