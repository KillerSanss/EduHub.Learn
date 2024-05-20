using Bogus;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;

namespace Eduhub.StudentService.Infrastructure.IntegrationTests.Generators;

public class EnrollmentGenerator
{
    private readonly Faker _faker = new();
    
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