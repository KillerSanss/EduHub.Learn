using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.EnrollmentService;

/// <summary>
/// Позитивные тесты сервиса зачислений
/// </summary>
[Collection("DatabaseCollection")]
public class EnrollmentServicePositiveTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly CourseGenerator _courseGenerator = new();
    private readonly StudentGenerator _studentGenerator = new();
    private readonly EnrollmentGenerator _enrollmentGenerator = new();
    private readonly EducatorGenerator _educatorGenerator = new();

    public EnrollmentServicePositiveTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка верного создания зачисления
    /// </summary>
    [Fact]
    public async Task Add_ReturnCreatedEnrollment()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);
        var addedEnrollment = _enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id);

        // Act
        var action = await enrollmentService.AddAsync(addedEnrollment,default);

        // Assert
        action.Should().NotBeNull();
        action.StartDate.Should().Be(addedEnrollment.StartDate);
        action.StudentId.Should().Be(addedEnrollment.StudentId);
        action.CourseId.Should().Be(addedEnrollment.CourseId);
    }

    /// <summary>
    /// Проверка получения всех существующих зачислений
    /// </summary>
    [Fact]
    public async Task GetAll_ReturnAllEnrollments()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);
        await enrollmentService.AddAsync(_enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id), default);

        // Act
        var enrollments = await enrollmentService.GetAllAsync(default);

        // Assert
        enrollments.Should().NotBeNull();
    }

    /// <summary>
    /// Проверка удаления зачисления
    /// </summary>
    [Fact]
    public async Task Delete_ShouldDeleteEnrollment()
    {
        // Assert
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentRepository = scope.ServiceProvider.GetRequiredService<IEnrollmentRepository>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);
        var addedEnrollment = await enrollmentService.AddAsync(_enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id), default);

        // Act
        await enrollmentService.DeleteAsync(addedEnrollment.Id, default);
        var action = await enrollmentRepository.GetByIdAsync(addedEnrollment.Id, default);

        // Assert
        action.Should().BeNull();
    }

    /// <summary>
    /// Проверка получения зачислений студента
    /// </summary>
    [Fact]
    public async Task GetStudentEnrollments_ReturnStudentEnrollments()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator(), default);
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id), default);
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);
        var addedEnrollment = await enrollmentService.AddAsync(_enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id), default);

        // Act
        var studentEnrollments = await enrollmentService.GetStudentEnrollmentsAsync(addedStudent.Id, default);

        // Assert
        studentEnrollments.Should().NotBeNull();
        studentEnrollments.Should().ContainSingle(e => e.Id == addedEnrollment.Id);
    }
}