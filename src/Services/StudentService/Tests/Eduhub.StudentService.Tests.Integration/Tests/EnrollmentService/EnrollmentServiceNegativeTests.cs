using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Tests.Shared.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.EnrollmentService;

/// <summary>
/// Негативные тесты сервиса зачислений
/// </summary>
[Collection(nameof(IntegrationTestCollection))]
public class EnrollmentServiceNegativeTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly Faker _faker = new();
    private readonly CourseGenerator _courseGenerator = new();
    private readonly StudentGenerator _studentGenerator = new();
    private readonly EducatorGenerator _educatorGenerator = new();

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
        var action = async () => await enrollmentService.DeleteAsync(Guid.NewGuid());

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Enrollment>>();
    }
    
    /// <summary>
    /// Проверка, что у метод AddAsync сервиса зачислений выбрасывает EntityNotFoundException для студента
    /// </summary>
    [Fact]
    public async Task Add_Enrollment_ThrowStudentNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        
        var educator = await educatorService.AddAsync(_educatorGenerator.GenerateEducatorDto());
        var course = await courseService.AddAsync(_courseGenerator.GenerateCourseDto(educator.Id));
        
        var enrollment = new CreateEnrollmentDto
        {
            CourseId = course.Id,
            StudentId = Guid.NewGuid(),
            StartDate = _faker.Date.Past()
        };
        
        // Act
        var action = async () => await enrollmentService.AddAsync(enrollment);
        
        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Student>>();
    }
    
    /// <summary>
    /// Проверка, что у метод AddAsync сервиса зачислений выбрасывает EntityNotFoundException для курса
    /// </summary>
    [Fact]
    public async Task Add_Enrollment_ThrowCourseNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        
        var student = await studentService.AddAsync(_studentGenerator.GenerateStudentDto());
        
        var enrollment = new CreateEnrollmentDto
        {
            CourseId = Guid.NewGuid(),
            StudentId = student.Id,
            StartDate = _faker.Date.Past()
        };
        
        // Act
        var action = async () => await enrollmentService.AddAsync(enrollment);
        
        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Course>>();
    }
}