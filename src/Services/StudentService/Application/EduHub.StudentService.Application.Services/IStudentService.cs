using EduHub.StudentService.Application.Services.Dto;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий StudentService
/// </summary>
public interface IStudentService
{
    Task<StudentDto> AsyncAddStudent(StudentDto studentDto);
    Task<StudentDto> AsyncUpdateStudent(StudentDto studentDto);
    Task<StudentDto> AsyncGetStudent(Guid studentId);
    Task<List<StudentDto>> AsyncGetAllStudents();
    Task AsyncDeleteStudent(Guid studentId);
}