namespace EduHub.StudentService.Application.Services.Dtos.Student;

/// <summary>
/// Дто студента
/// </summary>
public class StudentDto : BaseStudentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid Id { get; init; }
}