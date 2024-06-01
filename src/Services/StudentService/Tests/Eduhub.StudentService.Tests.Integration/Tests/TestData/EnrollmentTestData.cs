namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Tests.TestData;

/// <summary>
/// Класс генерации данных для сущности Enrollment в тестах
/// </summary>
public static class EnrollmentTestData
{
    /// <summary>
    /// Генерация данных для исключения EntityNotFoundException у сущности Enrollment
    /// </summary>
    public static IEnumerable<object[]> GetEnrollmentArgumentExceptionProperties()
    {
        return new List<object[]>
        {
            new object[] {Guid.NewGuid(), Guid.NewGuid()}
        };
    }
}