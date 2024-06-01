using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.EnrollmentService;

/// <summary>
/// Позитивные тесты сервиса зачислений
/// </summary>
[Collection(nameof(CollectionNames.DatabaseCollection))]
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
    public async Task Add_Enrollment_ReturnCreatedEnrollment()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id));
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent());
        var addedEnrollment = _enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id);

        // Act
        var action = await enrollmentService.AddAsync(addedEnrollment);

        // Assert
        action.Should().BeEquivalentTo(addedEnrollment, options => options
            .Excluding(e => e.Id));
    }

    /// <summary>
    /// Проверка получения всех существующих зачислений
    /// </summary>
    [Fact]
    public async Task GetAll_Enrollments_ReturnAllEnrollments()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id));
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent());
        var addedEnrollment = await enrollmentService.AddAsync(_enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id));

        // Act
        var enrollments = await enrollmentService.GetAllAsync();

        // Assert
        enrollments.Should().ContainSingle(e => e.Id == addedEnrollment.Id);
    }

    /// <summary>
    /// Проверка удаления зачисления
    /// </summary>
    [Fact]
    public async Task Delete_Enrollment_ReturnNull()
    {
        // Assert
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var enrollmentRepository = scope.ServiceProvider.GetRequiredService<IEnrollmentRepository>();
        var enrollmentService = scope.ServiceProvider.GetRequiredService<IEnrollmentService>();
        var educatorService = scope.ServiceProvider.GetRequiredService<IEducatorService>();
        var courseService = scope.ServiceProvider.GetRequiredService<ICourseService>();

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id));
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent());
        var addedEnrollment = await enrollmentService.AddAsync(_enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id));

        // Act
        await enrollmentService.DeleteAsync(addedEnrollment.Id);
        var action = await enrollmentRepository.GetByIdAsync(addedEnrollment.Id);

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

        var addedEducator = await educatorService.AddAsync(_educatorGenerator.GenerateEducator());
        var addedCourse = await courseService.AddAsync(_courseGenerator.GenerateCourse(addedEducator.Id));
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent());
        var addedEnrollment = await enrollmentService.AddAsync(_enrollmentGenerator.GenerateEnrollment(addedStudent.Id, addedCourse.Id));

        // Act
        var studentEnrollments = await enrollmentService.GetStudentEnrollmentsAsync(addedStudent.Id);

        // Assert
        studentEnrollments.Should().ContainSingle(e => e.Id == addedEnrollment.Id);
    }
}