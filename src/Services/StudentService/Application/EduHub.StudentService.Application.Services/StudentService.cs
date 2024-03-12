using EduHub.StudentService.Application.Services.DTOClasses;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    /// <summary>
    /// Добавление нового студента
    /// </summary>
    /// <param name="studentDto">Студент для добавления.</param>
    /// <returns>Добавленный студент.</returns>
    public async Task<StudentDto> AddStudent(StudentDto studentDto)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentDto.Id);
        if (existingStudent != null)
        {
            throw new InvalidOperationException("Student with the same id already exists");
        }

        var id = studentDto.Id;
        var fullName = studentDto.FullName;
        var gender = studentDto.Gender;
        var birthDate = studentDto.BirthDate;
        var email = studentDto.Email;
        var phone = studentDto.Phone;
        var address = studentDto.Address;
        var avatar = studentDto.Avatar;

        var newStudent = new Student(id, fullName, gender, birthDate, email, phone, address, avatar);

        await _studentRepository.AddStudent(newStudent);

        return new StudentDto
        {
            Id = newStudent.Id,
            FullName = newStudent.FullName,
            Gender = newStudent.Gender,
            BirthDate = newStudent.BirthDate,
            Email = newStudent.Email,
            Phone = newStudent.Phone,
            Address = newStudent.Address,
            Avatar = newStudent.Avatar
        };
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentDto">Студент для обновления.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<StudentDto> UpdateStudent(StudentDto studentDto)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentDto.Id);
        if (existingStudent == null)
        {
            throw new InvalidOperationException("Student does not exist");
        }

        existingStudent.FullName = studentDto.FullName;
        existingStudent.Gender = studentDto.Gender;
        existingStudent.BirthDate = studentDto.BirthDate;
        existingStudent.Email = studentDto.Email;
        existingStudent.Phone = studentDto.Phone;
        existingStudent.Address = studentDto.Address;
        existingStudent.Avatar = studentDto.Avatar;

        await _studentRepository.UpdateStudent(existingStudent);

        return studentDto;
    }

    /// <summary>
    /// Выбор одного студента
    /// </summary>
    /// <param name="studentId">Id студента.</param>
    /// <returns>Выбранный студент.</returns>
    public async Task<StudentDto> GetStudent(Guid studentId)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentId);
        if (existingStudent == null)
        {
            throw new InvalidOperationException("Student does not exist");
        }

        return new StudentDto
        {
            Id = existingStudent.Id,
            FullName = existingStudent.FullName,
            Gender = existingStudent.Gender,
            BirthDate = existingStudent.BirthDate,
            Email = existingStudent.Email,
            Phone = existingStudent.Phone,
            Address = existingStudent.Address,
            Avatar = existingStudent.Avatar
        };
    }

    /// <summary>
    /// Выбор списка студентов
    /// </summary>
    /// <returns>Список всех существующих студентов.</returns>
    public async Task<List<StudentDto>> GetAllStudents()
    {
        List<StudentDto> students = new List<StudentDto>();
        var allStudents = await _studentRepository.GetAllStudents();

        foreach (var student in allStudents)
        {
            var studentDto = new StudentDto
            {
                Id = student.Id,
                FullName = student.FullName,
                Gender = student.Gender,
                BirthDate = student.BirthDate,
                Email = student.Email,
                Phone = student.Phone,
                Address = student.Address,
                Avatar = student.Avatar
            };

            students.Add(studentDto);
        }

        return students;
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="studentId">Id студента.</param>
    /// <returns>Удаленный студент.</returns>
    public async Task<StudentDto> DeleteStudent(Guid studentId)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentId);
        if (existingStudent == null)
        {
            throw new InvalidOperationException("Student does not exist");
        }

        await _studentRepository.DeleteStudent(studentId);

        return new StudentDto
        {
            Id = existingStudent.Id,
            FullName = existingStudent.FullName,
            Gender = existingStudent.Gender,
            BirthDate = existingStudent.BirthDate,
            Email = existingStudent.Email,
            Phone = existingStudent.Phone,
            Address = existingStudent.Address,
            Avatar = existingStudent.Avatar
        };
    }
}