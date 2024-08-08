using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Constants;
using EduHub.StudentService.Application.Services.Dtos.Student;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using EduHub.StudentService.Application.Services.Validators.Student;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Entities.ValueObjects;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис студента
/// </summary>
public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly FileClient _fileClient;

    public StudentService(
        IStudentRepository studentRepository,
        IMapper mapper, IUnitOfWork unitOfWork,
        FileClient fileClient)
    {
        _studentRepository = Guard.Against.Null(studentRepository);
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
        _fileClient = fileClient;
    }

    /// <summary>
    /// Добавление нового студента
    /// </summary>
    /// <param name="studentDto">Студент для добавления.</param>
    /// <param name="fileStream">Поток файла изображения.</param>
    /// <param name="fileSize">Размер файла.</param>
    /// <param name="contentType">Тип содержимого файла.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный студент.</returns>
    public async Task<StudentDto> AddAsync(UpsertStudentDto studentDto, Stream fileStream, long fileSize, string contentType, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);
        await new StudentUpsertDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);
    
        var student = _mapper.Map<Student>(studentDto);
        await _studentRepository.AddAsync(student, cancellationToken);
        await SaveChangesOrThrowAsync(cancellationToken);

        await _fileClient.UploadFileAsync(student.Id.ToString(), fileStream, fileSize, contentType);

        return _mapper.Map<StudentDto>(student);
    }

    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="studentDto">Студент для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    public async Task<StudentDto> UpdateAsync(Guid id, UpsertStudentDto studentDto, Stream fileStream, long fileSize, string contentType, CancellationToken cancellationToken)
    {
        Guard.Against.Null(studentDto);
        Guard.Against.NullOrEmpty(id);
        
        await new StudentUpsertDtoValidator().ValidateAndThrowAsync(studentDto, cancellationToken);

        var student = await GetByIdOrThrowAsync(id, cancellationToken);

        await _fileClient.UploadFileAsync(student.Id.ToString(), fileStream, fileSize, contentType);
       
        student.Update(
            new FullName(studentDto.Surname, studentDto.FirstName, studentDto.Patronymic),
            studentDto.Gender,
            studentDto.BirthDate,
            new Email(studentDto.Email),
            new Phone(studentDto.Phone),
            new FullAddress(studentDto.City, studentDto.Street, studentDto.HouseNumber));

        await SaveChangesOrThrowAsync(cancellationToken);

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
        var student = await GetByIdOrThrowAsync(id, cancellationToken);

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
        var student = await GetByIdOrThrowAsync(id, cancellationToken);

        await _studentRepository.DeleteAsync(student, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task SaveChangesOrThrowAsync(CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
            when (ex.InnerException is not null && ex.Message.Contains(IndexConstants.UniqueStudentPhone))
        {
            throw new EntityConflictException<Student>(nameof(Student.Phone));
        }
        catch (Exception ex)
            when (ex.InnerException is not null && ex.Message.Contains(IndexConstants.UniqueStudentEmail))
        {
            throw new EntityConflictException<Student>(nameof(Student.Email));
        }
    }

    private async Task<Student> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(id, cancellationToken);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>(nameof(Student.Id), id.ToString());
        }

        return student;
    }
}