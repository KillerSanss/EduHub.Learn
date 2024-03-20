using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using EduHub.StudentService.Application.Services.UOW;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис студента
/// </summary>
public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public StudentService(IStudentRepository studentRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _studentRepository = Guard.Against.Null(studentRepository);
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Добавление нового студента
    /// </summary>
    /// <param name="student">Студент для добавления.</param>
    /// <returns>Добавленный студент.</returns>
    public async Task<StudentRecord> AddAsync(StudentRecord student, CancellationToken token)
    {
        Guard.Against.Null(student, nameof(student));

        var newStudent = _mapper.Map<Student>(student with { StudentId = Guid.NewGuid()});
        await _studentRepository.AddAsync(newStudent, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<StudentRecord>(newStudent);
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="student">Студент для обновления.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<StudentRecord> UpdateAsync(StudentRecord student, CancellationToken token)
    {
        Guard.Against.Null(student, nameof(student));

        var updatedStudent = _mapper.Map<Student>(student with { StudentId = Guid.NewGuid()});
        await _studentRepository.UpdateAsync(updatedStudent, token);

        await _unitOfWork.SaveChangesAsync(token);

        return _mapper.Map<StudentRecord>(updatedStudent);
    }

    /// <summary>
    /// Получение одного студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Выбранный студент.</returns>
    public async Task<StudentRecord> GetAsync(Guid studentId)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);
        if (student == null)
        {
            throw new EntityNotFoundException<Course>(nameof(studentId), studentId.ToString());
        }

        return _mapper.Map<StudentRecord>(student);
    }

    /// <summary>
    /// Получение списка студентов
    /// </summary>
    /// <returns>Список всех существующих студентов.</returns>
    public async Task<StudentRecord[]> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();
        return _mapper.Map<StudentRecord[]>(students);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    public async Task DeleteAsync(Guid studentId, CancellationToken token)
    {
        var deletedStudent = await _studentRepository.GetByIdAsync(studentId);
        if (deletedStudent == null)
        {
            throw new EntityNotFoundException<Course>(nameof(studentId), studentId.ToString());
        }

        await _studentRepository.DeleteAsync(deletedStudent, token);
        await _unitOfWork.SaveChangesAsync(token);
    }
}