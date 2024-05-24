namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.TestData;

/// <summary>
/// Класс генерации данных для сущности Enrollment в тестах
/// </summary>
public static class EnrollmentTestData
{
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
}