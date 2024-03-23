using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Interfaces.IRepositories;
using EduHub.StudentService.Application.Services.Interfaces.IServices;
using EduHub.StudentService.Application.Services.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;
using Eduhub.StudentService.Domain.Validations.Exceptions;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис зачисления
/// </summary>
public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
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
    public async Task<CreateEnrollmentDto> AddAsync(CreateEnrollmentDto enrollmentDto, CancellationToken cancellationToken)
    {
        Guard.Against.Null(enrollmentDto);

        var student = await _studentRepository.GetByIdAsync(enrollmentDto.StudentId, cancellationToken);
        if (student == null)
        {
            throw new EntityNotFoundException<Student>(nameof(CreateEnrollmentDto.StudentId), enrollmentDto.StudentId.ToString());
        }

        var course = await _courseRepository.GetByIdAsync(enrollmentDto.CourseId, cancellationToken);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(CreateEnrollmentDto.CourseId), enrollmentDto.CourseId.ToString());
        }

        await _enrollmentRepository.AddAsync(cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return enrollmentDto;
    }

    /// <summary>
    /// Получение зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив зачислений студента.</returns>
    public async Task<CreateEnrollmentDto[]> GetStudentEnrollmentsAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var studentEnrollments = await _enrollmentRepository.GetStudentEnrollmentsAsync(studentId, cancellationToken);
        return _mapper.Map<CreateEnrollmentDto[]>(studentEnrollments);
    }

    /// <summary>
    /// Получение всех зачислений
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Массив всех зачислений.</returns>
    public async Task<CreateEnrollmentDto[]> GetAllAsync(CancellationToken cancellationToken)
    {
        var enrollments = await _enrollmentRepository.GetAllAsync(cancellationToken);
        return _mapper.Map<CreateEnrollmentDto[]>(enrollments);
    }

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id, cancellationToken);
        if (enrollment == null)
        {
            throw new EntityNotFoundException<Enrollment>(nameof(Enrollment.Id), id.ToString());
        }

        await _enrollmentRepository.DeleteAsync(enrollment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}