using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using EduHub.StudentService.Application.Services.Validators.Enrollment;
using Eduhub.StudentService.Domain.Entities;
using FluentValidation;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис зачисления
/// </summary>
public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _enrollmentRepository = Guard.Against.Null(enrollmentRepository);
        _courseRepository = Guard.Against.Null(courseRepository);
        _studentRepository = Guard.Against.Null(studentRepository);
        _mapper = Guard.Against.Null(mapper);
        _unitOfWork = Guard.Against.Null(unitOfWork);
    }

    /// <summary>
    /// Зачисления студента на выбранный курс
    /// </summary>
    /// <param name="enrollmentDto">Дто зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Новое зачисление.</returns>
    public async Task<EnrollmentDto> AddAsync(CreateEnrollmentDto enrollmentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(enrollmentDto);

        await new EnrollmentCreateDtoValidator().ValidateAndThrowAsync(enrollmentDto, cancellationToken);
        
        var enrollment = _mapper.Map<Enrollment>(enrollmentDto);
        
        await CourseExistOrThrowAsync(enrollment.CourseId, cancellationToken);
        await StudentExistOrThrowAsync(enrollment.StudentId, cancellationToken);
        
        await _enrollmentRepository.AddAsync(enrollment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return _mapper.Map<EnrollmentDto>(enrollment);
    }

    /// <summary>
    /// Получение зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив зачислений студента.</returns>
    public async Task<EnrollmentOfStudentDto[]> GetStudentEnrollmentsAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var studentEnrollments = await _enrollmentRepository.GetStudentEnrollmentsAsync(studentId, cancellationToken);
        return _mapper.Map<EnrollmentOfStudentDto[]>(studentEnrollments);
    }

    /// <summary>
    /// Получение всех зачислений
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех зачислений.</returns>
    public async Task<EnrollmentDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var enrollments = await _enrollmentRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<EnrollmentDto[]>(enrollments);
    }

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var enrollment = await GetByIdOrThrowAsync(id, cancellationToken);

        await _enrollmentRepository.DeleteAsync(enrollment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<Enrollment> GetByIdOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id, cancellationToken);
        if (enrollment == null)
        {
            throw new EntityNotFoundException<Enrollment>(nameof(Enrollment.Id), id.ToString());
        }

        return enrollment;
    }
    
    private async Task CourseExistOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetByIdAsync(id, cancellationToken);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(Enrollment.CourseId), id.ToString());
        }
    }
    
    private async Task StudentExistOrThrowAsync(Guid id, CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(id, cancellationToken);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>(nameof(Enrollment.StudentId), id.ToString());
        }
    }
}