﻿using Eduhub.StudentService.Tests.Unit.Generators;
using FluentAssertions;
using Bogus;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Tests.Unit.Tests.EducatorTests;

/// <summary>
/// Позитивные unit тесты для сущности Educator.
/// </summary>
public class EducatorPositiveTests
{
    private readonly Faker _faker = new Faker();

    /// <summary>
    /// Проверка, что у сущности Educator корректно создается экземпляр.
    /// </summary>
    [Fact]
    public void Add_EducatorInstance_ReturnEducator()
    {
        // Arrange
        var id = _faker.Random.Guid();
        var fullName = new FullName(_faker.Name.LastName(), _faker.Name.FirstName(), _faker.Name.LastName());
        var gender = Gender.Male;
        var workExperience = _faker.Random.Int(1);
        var startDate = _faker.Date.Past();
        var phone = new Phone(_faker.Phone.PhoneNumber("+373########"));

        // Act
        var educator = new Educator(id, fullName, gender, workExperience, startDate, phone);

        // Assert
        educator.Should().NotBeNull();
        educator.Id.Should().Be(id);
        educator.FullName.Should().Be(fullName);
        educator.Gender.Should().Be(gender);
        educator.WorkExperience.Should().Be(workExperience);
        educator.StartDate.Should().Be(startDate);
        educator.Phone.Should().Be(phone);
    }

    /// <summary>
    /// Проверка, что метод Update обновляет экземпляр сущности Educator.
    /// </summary>
    [Fact]
    public void Update_EducatorInstance_UpdatedEducator()
    {
        // Arrange
        var educator = EducatorGenerator.GenerateEducator();
        var newEducator = EducatorGenerator.GenerateEducator();

        // Act
        educator.Update(newEducator.FullName,
            newEducator.Gender,
            newEducator.WorkExperience,
            newEducator.StartDate,
            newEducator.Phone);

        // Assert
        educator.Should().BeEquivalentTo(newEducator, options => options
            .Excluding(o => o.Id)
            .ExcludingNestedObjects());
    }

    /// <summary>
    /// Проверка, что метод GetCourse возвращает список курсов преподавателя.
    /// </summary>
    [Fact]
    public void GetCourse_ReturnIEnumerable()
    {
        // Arrange
        var educator = EducatorGenerator.GenerateEducator();

        // Act
        var educatorCourses = educator.GetCourse();

        // Assert
        educatorCourses.Should().NotBeNull();
    }
}