using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.TestData;
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
    private readonly Faker _faker = new();
    
    public static IEnumerable<object[]> TestEnrollmentArgumentExceptionData = EnrollmentTestData.GetEnrollmentArgumentExceptionProperties();

    public EnrollmentServiceNegativeTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync сервиса зачислений выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task Delete_Enrollment_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();

        // Act
        var action = async () => await enrollmentService.DeleteAsync(Guid.NewGuid(), default);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Enrollment>>();
    }
    
    /// <summary>
    /// Проверка, что у метод AddAsync сервиса зачислений выбрасывает ArgumentException
    /// </summary>
    [Theory]
    [MemberData(nameof(TestEnrollmentArgumentExceptionData))]
    public async Task Add_Enrollment_ThrowDbUpdateException(Guid courseId, Guid studentId)
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        
        var enrollment = new CreateEnrollmentDto
        {
            Id = Guid.NewGuid(),
            CourseId = courseId,
            StudentId = studentId,
            StartDate = _faker.Date.Past()
        };
        
        // Act
        var action = async () => await enrollmentService.AddAsync(enrollment, default);
        
        // Assert
        await action.Should().ThrowAsync<ArgumentException>();
    }
}