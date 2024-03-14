using EduHub.StudentService.Application.Services.Dto;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services;

/// <summary>
/// Интерфейс описывающий StudentService
/// </summary>
public interface IStudentService
{
    Task<Student> AsyncAddStudent(StudentDto studentDto);
    Task<Student> AsyncUpdateStudent(StudentDto studentDto);
    Task<Student> AsyncGetStudent(Guid studentId);
    Task<List<Student>> AsyncGetAllStudents();
    Task<Student> AsyncDeleteStudent(Guid studentId);
}