using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using EduHub.StudentService.Application.Services.Exceptions;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис студента
/// </summary>
public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;

    public StudentService(IStudentRepository studentRepository, IMapper mapper)
    {
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Добавление нового студента
    /// </summary>
    /// <param name="studentDto">Студент для добавления.</param>
    /// <returns>Добавленный студент.</returns>
    public async Task<Student> AsyncAddStudent(StudentDto studentDto)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentDto.Id);
        if (existingStudent != null)
        {
            throw new EntityConflictException<StudentDto>(studentDto, "Educator is already exist");
        }

        var newStudent = _mapper.Map<Student>(studentDto);
        await _studentRepository.AddStudent(newStudent);

        return newStudent;
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentDto">Студент для обновления.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<Student> AsyncUpdateStudent(StudentDto studentDto)
    {
        var updatedStudent = _mapper.Map<Student>(studentDto);
        await _studentRepository.UpdateStudent(updatedStudent);

        return updatedStudent;
    }

    /// <summary>
    /// Выбор одного студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Выбранный студент.</returns>
    public async Task<Student> AsyncGetStudent(Guid studentId)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentId);
        if (existingStudent == null)
        {
            throw new EntityNotFoundException<Guid>(studentId, "Student does not exist");
        }

        return existingStudent;
    }

    /// <summary>
    /// Выбор списка студентов
    /// </summary>
    /// <returns>Список всех существующих студентов.</returns>
    public async Task<List<Student>> AsyncGetAllStudents()
    {
        var allStudents = await _studentRepository.GetAllStudents();

        return _mapper.Map<List<Student>>(allStudents);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Удаленный студент.</returns>
    public async Task<Student> AsyncDeleteStudent(Guid studentId)
    {
        var deletedStudent = await _studentRepository.GetStudentById(studentId);
        if (deletedStudent == null)
        {
            throw new EntityNotFoundException<Guid>(studentId, "Student does not exist");
        }

        await _studentRepository.DeleteStudent(studentId);

        return deletedStudent;
    }
}