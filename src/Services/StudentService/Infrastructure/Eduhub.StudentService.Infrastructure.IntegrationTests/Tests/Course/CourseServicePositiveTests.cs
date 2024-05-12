using AutoMapper;
using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using EduHub.StudentService.Application.Services.Mapping;
using EduHub.StudentService.Application.Services.Services;
using EduHub.StudentService.Tests.Unit.Infrastructure.Generators;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.Course;

/// <summary>
/// Позитивные тесты сервиса курса
/// </summary>
[Collection("DatabaseCollection")]
public class CourseServicePositiveTests
{
    private readonly DatabaseFixture _fixture;
    private readonly Faker _faker = new();

    public CourseServicePositiveTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка верного создания курса
    /// </summary>
    [Fact]
    public async Task AddAsync_ReturnCreatedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));

        var educator = EducatorGenerator.GenerateEducator();

        await educatorRepository.AddAsync(educator, CancellationToken.None);
        var service = new CourseService(courseRepository, mapper, unitOfWork);

        var name = _faker.Random.String(2);
        var description = _faker.Lorem.Sentence();
        var educatorId = educator.Id;

        var course = new CreateCourseDto
        {
            Name = name,
            Description = description,
            EducatorId = educatorId
        };

        // Act
        var result = await service.AddAsync(course, CancellationToken.None);

        // Assert
        result.Name.Should().Be(name);
        result.Description.Should().Be(description);
        result.EducatorId.Should().Be(educatorId);
    }

    /// <summary>
    /// Проверка обновления курса
    /// </summary>
    [Fact]
    public async Task UpdateAsync_ReturnUpdatedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));

        var educator = EducatorGenerator.GenerateEducator();
        await educatorRepository.AddAsync(educator, CancellationToken.None);

        var course = new CreateCourseDto
        {
            Name = _faker.Random.String(2),
            Description = _faker.Lorem.Sentence(),
            EducatorId = educator.Id
        };

        var service = new CourseService(courseRepository, mapper, unitOfWork);
        var addedCourse = await service.AddAsync(course, CancellationToken.None);

        var updatedCourseInfo = new UpdateCourseDto
        {
            Id = addedCourse.Id,
            Name = _faker.Random.String(2),
            Description = _faker.Lorem.Sentence(),
            EducatorId = educator.Id
        };

        // Act
        var updatedCourse = await service.UpdateAsync(updatedCourseInfo, CancellationToken.None);

        // Assert
        updatedCourse.Should().NotBeNull();
        updatedCourse.Name.Should().Be(updatedCourseInfo.Name);
        updatedCourse.Description.Should().Be(updatedCourseInfo.Description);
    }

    /// <summary>
    /// Проверка получения всех существующих курсов
    /// </summary>
    [Fact]
    public async Task GetAllAsync_ReturnAllCourses()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));

        var educator = EducatorGenerator.GenerateEducator();
        await educatorRepository.AddAsync(educator, CancellationToken.None);

        var course = new CreateCourseDto
        {
            Name = _faker.Random.String(2),
            Description = _faker.Lorem.Sentence(),
            EducatorId = educator.Id
        };

        var service = new CourseService(courseRepository, mapper, unitOfWork);
        await service.AddAsync(course, CancellationToken.None);

        // Act
        var courses = service.GetAllAsync(CancellationToken.None);

        // Assert
        courses.Should().NotBeNull();
    }

    /// <summary>
    /// Проверка выбор верного курса по идентификатору
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ReturnSelectedCourse()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));

        var educator = EducatorGenerator.GenerateEducator();
        await educatorRepository.AddAsync(educator, CancellationToken.None);

        var course = new CreateCourseDto
        {
            Name = _faker.Random.String(2),
            Description = _faker.Lorem.Sentence(),
            EducatorId = educator.Id
        };

        var service = new CourseService(courseRepository, mapper, unitOfWork);
        var addedCourse = await service.AddAsync(course, CancellationToken.None);

        // Act
        var selectedCourse = await service.GetByIdAsync(addedCourse.Id, CancellationToken.None);

        // Assert
        selectedCourse.Id.Should().Be(addedCourse.Id);
        selectedCourse.Name.Should().Be(course.Name);
        selectedCourse.Description.Should().Be(course.Description);
        selectedCourse.EducatorId.Should().Be(course.EducatorId);
    }

    /// <summary>
    /// Проверка удаления курса
    /// </summary>
    [Fact]
    public async Task DeleteAsync_ShouldDeleteCourseFromRepository()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));

        var educator = EducatorGenerator.GenerateEducator();
        await educatorRepository.AddAsync(educator, CancellationToken.None);

        var course = new CreateCourseDto
        {
            Name = _faker.Random.String(2),
            Description = _faker.Lorem.Sentence(),
            EducatorId = educator.Id
        };

        var service = new CourseService(courseRepository, mapper, unitOfWork);

        var addedCourse = await service.AddAsync(course, CancellationToken.None);

        // Act
        await service.DeleteAsync(addedCourse.Id, CancellationToken.None);
        var deletedCourse = await courseRepository.GetByIdAsync(addedCourse.Id, CancellationToken.None);

        // Assert
        deletedCourse.Should().BeNull();
    }
}