using EduHub.StudentService.Application.Services;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Eduhub.StudentService.Infrastructure.IntegrationTests.Fixture;
using Eduhub.StudentService.Tests.Shared.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.StudentService;

/// <summary>
/// Позитивные тесты сервиса студента
/// </summary>
[Collection(nameof(IntegrationTestCollection))]
public class StudentServicePositiveTests
{
    private readonly IntegrationTestFixture _fixture;
    private readonly StudentGenerator _studentGenerator = new();
    private readonly FileGetter _file = new();
    private readonly FileClient _fileClient;

    public StudentServicePositiveTests(IntegrationTestFixture fixture)
    {
        _fixture = fixture;
        using var scope = _fixture.ServiceProvider.CreateScope();
        _fileClient = scope.ServiceProvider.GetRequiredService<FileClient>();
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

        var addedStudent = _studentGenerator.GenerateUpsertStudentDto();
        
        // Act
        var action = await studentService.AddAsync(addedStudent, _file.GetTestAvatar());
        
        // Assert
        action.Should().BeEquivalentTo(addedStudent);

        await _fileClient.DeleteAllObjectsInBucketAsync();
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

        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateUpsertStudentDto(), _file.GetTestAvatar());

        var newStudent = _studentGenerator.GenerateUpsertStudentDto();

        // Act
        var action = await studentService.UpdateAsync(addedStudent.Id, newStudent, _file.GetTestAvatar());

        // Assert
        action.Should().BeEquivalentTo(newStudent);
        
        await _fileClient.DeleteAllObjectsInBucketAsync();
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
        
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateUpsertStudentDto(), _file.GetTestAvatar());

        // Act
        var students = await studentService.GetAllAsync();

        // Assert
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
        
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateUpsertStudentDto(), _file.GetTestAvatar());

        // Act
        var selectedStudent = await studentService.GetByIdAsync(addedStudent.Id);

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
        
        var addedStudent = await studentService.AddAsync(_studentGenerator.GenerateUpsertStudentDto(), _file.GetTestAvatar());

        // Act
        await studentService.DeleteAsync(addedStudent.Id);
        var action = await studentRepository.GetByIdAsync(addedStudent.Id);

        // Assert
        action.Should().BeNull();
    }
}