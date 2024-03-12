using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services;

public interface IStudentRepository
{
    Task<Student> GetStudentById(Guid studentId);
    Task<Student> AddStudent(Student student);
    Task<Student> UpdateStudent(Student student);
    Task<Student> DeleteStudent(Guid studentId);
    Task<List<Student>> GetAllStudents();
}