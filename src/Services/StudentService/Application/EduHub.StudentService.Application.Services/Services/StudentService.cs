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
    public async Task<StudentDto> AsyncAddStudent(StudentDto studentDto)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentDto.Id);
        if (existingStudent != null)
        {
            throw new EntityConflictException<StudentDto>(studentDto, "Educator is already exist");
        }

        var newStudent = _mapper.Map<Student>(studentDto);
        await _studentRepository.AddStudent(newStudent);

        return _mapper.Map<StudentDto>(newStudent);
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentDto">Студент для обновления.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<StudentDto> AsyncUpdateStudent(StudentDto studentDto)
    {
        var updatedStudent = _mapper.Map<Student>(studentDto);
        await _studentRepository.UpdateStudent(updatedStudent);

        return _mapper.Map<StudentDto>(updatedStudent);
    }

    /// <summary>
    /// Выбор одного студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Выбранный студент.</returns>
    public async Task<StudentDto> AsyncGetStudent(Guid studentId)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentId);
        if (existingStudent == null)
        {
            throw new EntityNotFoundException<Guid>(studentId, "Student does not exist");
        }

        return _mapper.Map<StudentDto>(existingStudent);
    }

    /// <summary>
    /// Выбор списка студентов
    /// </summary>
    /// <returns>Список всех существующих студентов.</returns>
    public async Task<List<StudentDto>> AsyncGetAllStudents()
    {
        var allStudents = await _studentRepository.GetAllStudents();

        return _mapper.Map<List<StudentDto>>(allStudents);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    public async Task AsyncDeleteStudent(Guid studentId)
    {
        var deletedStudent = await _studentRepository.GetStudentById(studentId);
        if (deletedStudent == null)
        {
            throw new EntityNotFoundException<Guid>(studentId, "Student does not exist");
        }

        await _studentRepository.DeleteStudent(studentId);
    }
}