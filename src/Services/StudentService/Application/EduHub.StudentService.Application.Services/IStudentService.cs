using EduHub.StudentService.Application.Services.DTOClasses;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий StudentService
/// </summary>
public interface IStudentService
{
    Task<StudentDto> AddStudent(StudentDto studentDto);
    Task<StudentDto> UpdateStudent(StudentDto studentDto);
    Task<StudentDto> GetStudent(Guid studentId);
    Task<List<StudentDto>> GetAllStudents();
    Task<StudentDto> DeleteStudent(Guid studentId);
}