using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

/// <summary>
/// Класс генерации зачисления
/// </summary>
public class EnrollmentGenerator
{
    private readonly Faker _faker = new();

    /// <summary>
    /// Генерация зачисления
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <returns>Зачисление.</returns>
    public CreateEnrollmentDto GenerateEnrollment(Guid studentId, Guid courseId)
    {
        var enrollment = new CreateEnrollmentDto
        {
            StartDate = _faker.Date.Past(),
            CourseId = courseId,
            StudentId = studentId
        };

        return enrollment;
    }
}