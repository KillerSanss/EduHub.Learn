using EduHub.StudentService.Application.Services;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Tests.Shared.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.StudentService;

/// <summary>
/// Негативные тесты сервиса студента
/// </summary>
[Collection(nameof(IntegrationTestCollection))]
public class StudentServiceNegativeTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly FileGetter _file = new();
    private readonly StudentGenerator _studentGenerator = new();
    private readonly FileClient _fileClient;

    public StudentServiceNegativeTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
        using var scope = _fixture.ServiceProvider.CreateScope();
        _fileClient = scope.ServiceProvider.GetRequiredService<FileClient>();
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync сервиса студента выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Delete_Student_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        // Act
        var action = async () => await studentService.DeleteAsync(Guid.NewGuid());

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Student>>();
    }

    /// <summary>
    /// Проверка, что у метода GetByIdAsync сервиса студента выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task GetById_Student_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        // Act
        var action = async () => await studentService.GetByIdAsync(Guid.NewGuid());

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Student>>();
    }
    
    /// <summary>
    /// Проверка, что у метода UpdateAsync сервиса студента выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Update_Student_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        // Act
        var action = async () => await studentService.UpdateAsync(
            Guid.NewGuid(),
            _studentGenerator.GenerateUpsertStudentDto(),
            _file.GetTestAvatar());

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Student>>();
        
        await _fileClient.DeleteAllObjectsInBucketAsync();
    }
}