using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using Eduhub.StudentService.Domain.Entities;

namespace Eduhub.StudentService.Tests.Shared.Generators;

public class EnrollmentGenerator
{
    private readonly Faker _faker = new();
    
    /// <summary>
    /// Генерация зачисления
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <returns>Зачисление.</returns>
    public CreateEnrollmentDto GenerateEnrollmentDto(Guid studentId, Guid courseId)
    {
        var enrollment = new CreateEnrollmentDto
        {
            StartDate = _faker.Date.Past(),
            CourseId = courseId,
            StudentId = studentId
        };
        
        return enrollment;
    }
    
    private static readonly Faker<Enrollment> Faker = new Faker<Enrollment>()
        .CustomInstantiator(f => new Enrollment(
            f.Random.Guid(),
            f.Random.Guid(),
            f.Random.Guid(),
            f.Date.Past()
        ));
    
    public static Enrollment GenerateEnrollment()
    {
        return Faker.Generate();
    }
}