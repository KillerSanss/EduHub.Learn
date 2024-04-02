namespace EduHub.StudentService.Application.Services.Dtos.Student;

/// <summary>
/// Дто для студента
/// </summary>
public class UpdateStudentDto : BaseStudentDto
{
    /// <summary>
    /// Идентификатор студента
    /// </summary>
    public Guid Id { get; init;  }
}
