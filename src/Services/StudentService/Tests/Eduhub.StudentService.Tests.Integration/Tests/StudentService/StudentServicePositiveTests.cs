using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.StudentService;

/// <summary>
/// Позитивные тесты сервиса студента
/// </summary>
[Collection("DatabaseCollection")]
public class StudentServicePositiveTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly StudentGenerator _studentGenerator = new();

    public StudentServicePositiveTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка верного создания студента
    /// </summary>
    [Fact]
    public async Task Add_Student_ReturnCreatedStudent()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        var addedStudent = _studentGenerator.GenerateStudent();

        // Act
        var action = await studentService.AddAsync(addedStudent, default);

        // Assert
        action.Should().BeEquivalentTo(addedStudent, options => options
            .Excluding(s => s.Phone)
            .Excluding(s => s.Email));

        action.Phone.Should().Be(new Phone(addedStudent.Phone).ToString());
        action.Email.Should().Be(new Email(addedStudent.Email).ToString());
    }

    /// <summary>
    /// Проверка обновления студента
    /// </summary>
    [Fact]
    public async Task Update_Student_ReturnUpdatedStudent()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);

        var newStudent = _studentGenerator.GenerateUpdateStudent(addedStudent.Id);

        // Act
        var action = await studentService.UpdateAsync(newStudent, default);

        // Assert
        action.Should().BeEquivalentTo(newStudent, options => options
            .Excluding(s => s.Phone)
            .Excluding(s => s.Email));

        action.Phone.Should().Be(new Phone(newStudent.Phone).ToString());
        action.Email.Should().Be(new Email(newStudent.Email).ToString());
    }

    /// <summary>
    /// Проверка получения всех существующих студентов
    /// </summary>
    [Fact]
    public async Task GetAll_Students_ReturnAllStudents()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);

        // Act
        var students = await studentService.GetAllAsync(default);

        // Assert
        students.Should().NotBeEmpty();
        students.Should().ContainSingle(e => e.Id == addedStudent.Id);
    }

    /// <summary>
    /// Проверка выбор верного студента по идентификатору
    /// </summary>
    [Fact]
    public async Task GetById_Student_ReturnSelectedStudent()
    {
        // Assert
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();

        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);

        // Act
        var selectedStudent = await studentService.GetByIdAsync(addedStudent.Id, default);

        // Assert
        selectedStudent.Should().BeEquivalentTo(addedStudent);
    }

    /// <summary>
    /// Проверка удаления студента
    /// </summary>
    [Fact]
    public async Task Delete_Student_ReturnNull()
    {
        // Assert
        using var scope = _fixture.ServiceProvider.CreateScope();
        var studentService = scope.ServiceProvider.GetRequiredService<IStudentService>();
        var studentRepository = scope.ServiceProvider.GetRequiredService<IStudentRepository>();

        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateStudent(), default);

        // Act
        await studentService.DeleteAsync(addedStudent.Id, default);
        var action = await studentRepository.GetByIdAsync(addedStudent.Id, default);

        // Assert
        action.Should().BeNull();
    }
}