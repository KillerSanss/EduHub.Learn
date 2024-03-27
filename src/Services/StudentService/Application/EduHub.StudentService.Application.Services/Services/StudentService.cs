using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Student;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;

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
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Добавление нового студента
    /// </summary>
    /// <param name="studentDto">Студент для добавления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный студент.</returns>
    public async Task<StudentDto> AddAsync(CreateStudentDto studentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);

        var student = _mapper.Map<Student>(studentDto);
        await _studentRepository.AddAsync(student, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<StudentDto>(student);
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentDto">Студент для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<StudentDto> UpdateAsync(UpdateStudentDto studentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);

        var student = await IsExistStudentAsync(studentDto.Id, cancellationToken);
        student.Update(
            new FullName(studentDto.Surname, studentDto.FirstName, studentDto.Patronymic),
            studentDto.Gender,
            studentDto.BirthDate,
            new Email(studentDto.Email),
            new Phone(studentDto.Phone),
            new FullAddress(studentDto.City, studentDto.Street, studentDto.HouseNumber),
            studentDto.Avatar);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<StudentDto>(student);
    }

    /// <summary>
    /// Получение одного студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный студент.</returns>
    public async Task<StudentDto> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await IsExistStudentAsync(id, cancellationToken);

        return _mapper.Map<StudentDto>(student);
    }

    /// <summary>
    /// Получение списка студентов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив студентов.</returns>
    public async Task<StudentDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var students = await _studentRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<StudentDto[]>(students);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await IsExistStudentAsync(id, cancellationToken);

        await _studentRepository.DeleteAsync(student, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<Student> IsExistStudentAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(id, cancellationToken);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>(nameof(Student.Id), id.ToString());
        }

        return student;
    }
}