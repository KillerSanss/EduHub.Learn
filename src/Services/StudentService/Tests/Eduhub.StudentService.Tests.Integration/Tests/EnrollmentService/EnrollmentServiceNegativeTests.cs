using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.EnrollmentService;

/// <summary>
/// Негативные тесты сервиса зачислений
/// </summary>
[Collection("DatabaseCollection")]
public class EnrollmentServiceNegativeTests
{
    private readonly IntegrationTestFixture _fixture;

    public EnrollmentServiceNegativeTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync сервиса зачислений выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Delete_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();

        // Act
        var action = async () => await enrollmentService.DeleteAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Enrollment>>();
    }
}