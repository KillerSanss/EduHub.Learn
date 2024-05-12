using AutoMapper;
using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Exceptions;
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
/// Негативные тесты сервиса курса
/// </summary>
[Collection("DatabaseCollection")]
public class CourseServiceNegativeTests
{
    private readonly DatabaseFixture _fixture;
    private readonly Faker _faker = new();

    public CourseServiceNegativeTests(DatabaseFixture fixture)
    {
        _fixture = fixture;
    }

    /// <summary>
    /// Проверка, что у метода DeleteAsync у сервиса курса выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task DeleteAsync_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        var service = new CourseService(courseRepository, mapper, unitOfWork);

        // Act
        Func<Task> action = async () => await service.DeleteAsync(Guid.NewGuid(), CancellationToken.None);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }

    /// <summary>
    /// Проверка, что у метода GetByIdAsync у сервиса курса выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        var service = new CourseService(courseRepository, mapper, unitOfWork);

        // Act
        Func<Task> action = async () => await service.GetByIdAsync(Guid.NewGuid(), CancellationToken.None);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }

    /// <summary>
    /// Проверка, что у метода UpdateAsync у сервиса курса выбрасывается EntityNotFoundException
    /// </summary>
    [Fact]
    public async Task UpdateAsync_ThrowEntityNotFoundException()
    {
        // Arrange
        using var scope = _fixture.ServiceProvider.CreateScope();
        var courseRepository = scope.ServiceProvider.GetRequiredService<ICourseRepository>();
        var educatorRepository = scope.ServiceProvider.GetRequiredService<IEducatorRepository>();
        var mapper = new Mapper(new MapperConfiguration(cfg => cfg.AddProfile(new CourseMappingProfile())));
        var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

        var service = new CourseService(courseRepository, mapper, unitOfWork);

        var educator = EducatorGenerator.GenerateEducator();
        await educatorRepository.AddAsync(educator, CancellationToken.None);

        var course = new UpdateCourseDto
        {
            Name = _faker.Random.String(2),
            Description = _faker.Lorem.Sentence(),
            EducatorId = educator.Id
        };

        // Act
        Func<Task> action = async () => await service.UpdateAsync(course, CancellationToken.None);

        // Assert
        await action.Should().ThrowAsync<EntityNotFoundException<Domain.Entities.Course>>();
    }
}