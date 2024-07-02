namespace EduHub.StudentService.Application.Services.Dtos.Enrollment;

/// <summary>
/// Дто зачисления
/// </summary>
public class EnrollmentOfStudentDto : BaseEnrollmentDto
{
    /// <summary>
    /// Идентификатор зачисления
    /// </summary>
    public Guid Id { get; init; }
    
    /// <summary>
    /// Название курса
    /// </summary>
    public string Name { get; init; }
}