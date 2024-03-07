using Bogus;
using Eduhub.StudentService.Domain.Entities.Enums;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

namespace EduHub.StudentService.Tests.Unit.Infrastucture.Data;

/// <summary>
/// Класс генерации тестовых данных для вызова исключений
/// </summary>
public static class TestData
{
    private static readonly Faker Faker = new();

    /// <summary>
    /// Генерация данных для исключения ArgumentException у сущности Student
    /// </summary>
    public static IEnumerable<object[]> GetStudentArgumentExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {null, new FullAddress(Faker.Address.City(), Faker.Address.StreetName(), Faker.Random.Int(1, 100))},
            new object[] {new FullName(Faker.Name.LastName(), Faker.Name.FirstName(), Faker.Name.LastName()), null}
        };
    }

    /// <summary>
    /// Генерация данных для исключения GuardValidationException у сущности Student
    /// </summary>
    public static IEnumerable<object[]> GetStudentGuardValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {Gender.None, Faker.Date.Past(), Faker.Image.PicsumUrl() + Faker.PickRandom(".jpeg", ".png")},
            new object[] {Gender.Male, Faker.Date.Future(), Faker.Image.PicsumUrl() + Faker.PickRandom(".jpeg", ".png")},
            new object[] {Gender.Male, Faker.Date.Past(), "----"}
        };
    }

    /// <summary>
    /// Генерация данных для исключения ArgumentException у сущности Enrollment
    /// </summary>
    public static IEnumerable<object[]> GetEnrollmentArgumentExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {Guid.Empty, Guid.NewGuid()},
            new object[] {Guid.NewGuid(), Guid.Empty}
        };
    }

    /// <summary>
    /// Генерация данных для исключения GuardValidationException у сущности Enrollment
    /// </summary>
    public static IEnumerable<object[]> GetEnrollmentGuardValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {Faker.Date.Future()}
        };
    }

    /// <summary>
    /// Генерация данных для исключения ArgumentException у сущности Educator
    /// </summary>
    public static IEnumerable<object[]> GetEducatorArgumentExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {null, 1},
            new object[] {new FullName(Faker.Name.LastName(), Faker.Name.FirstName(), Faker.Name.LastName()), -1}
        };
    }

    /// <summary>
    /// Генерация данных для исключения GuardValidationException у сущности Educator
    /// </summary>
    public static IEnumerable<object[]> GetEducatorGuardValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {Gender.None, Faker.Date.Past()},
            new object[] {Gender.Male, Faker.Date.Future()}
        };
    }

    /// <summary>
    /// Генерация данных для исключения ArgumentException у сущности Course
    /// </summary>
    public static IEnumerable<object[]> GetCourseArgumentExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {null, Guid.NewGuid()},
            new object[] {Faker.Random.String(10), Guid.Empty}
        };
    }

    /// <summary>
    /// Генерация данных для исключения GuardValidationException у сущности Course
    /// </summary>
    public static IEnumerable<object[]> GetCourseGuardValidationExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {Faker.Random.String(51)}
        };
    }
}