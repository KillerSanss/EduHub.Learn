using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dto;
using EduHub.StudentService.Application.Services.Repositories;
using EduHub.StudentService.Application.Services.UOW;
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

    public EnrollmentService(IEnrollmentRepository enrollmentRepository,
        ICourseRepository courseRepository,
        IStudentRepository studentRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _enrollmentRepository = Guard.Against.Null(enrollmentRepository);
        _courseRepository = Guard.Against.Null(courseRepository);
        _studentRepository = Guard.Against.Null(studentRepository);
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    /// <summary>
    /// Зачисления студента на выбранный курс
    /// </summary>
    /// <param name="enrollmentDto">Дто зачисления.</param>
    /// <returns>Новое зачисление.</returns>
    public async Task EnrollStudentAsync(EnrollmentDto enrollmentDto, CancellationToken token)
    {
        Guard.Against.Null(enrollmentDto);

        var student = await _studentRepository.GetByIdAsync(enrollmentDto.StudentId);
        if (student == null)
        {
            throw new EntityNotFoundException<Course>(nameof(enrollmentDto.StudentId), enrollmentDto.StudentId.ToString());
        }

        var course = await _courseRepository.GetByIdAsync(enrollmentDto.CourseId);
        if (course == null)
        {
            throw new EntityNotFoundException<Course>(nameof(enrollmentDto.CourseId), enrollmentDto.CourseId.ToString());
        }

        await _enrollmentRepository.EnrollStudentAsync(token);
    }

    /// <summary>
    /// Получение зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Массив зачислений студента.</returns>
    public async Task<EnrollmentDto[]> GetStudentEnrollmentsAsync(Guid studentId)
    {
        var studentEnrollments = await _enrollmentRepository.GetStudentEnrollmentsAsync(studentId);
        return _mapper.Map<EnrollmentDto[]>(studentEnrollments);
    }

    /// <summary>
    /// Получение всех зачислений
    /// </summary>
    /// <returns> Массив всех зачислений.</returns>
    public async Task<EnrollmentDto[]> GetAllAsync()
    {
        var enrollments = await _enrollmentRepository.GetAllAsync();
        return _mapper.Map<EnrollmentDto[]>(enrollments);
    }

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="enrollmentId">Идентификатор зачисления.</param>
    public async Task DeleteAsync(Guid enrollmentId, CancellationToken token)
    {
        var deletedEnrollment = await _enrollmentRepository.GetByIdAsync(enrollmentId);
        if (deletedEnrollment == null)
        {
            throw new EntityNotFoundException<Course>(nameof(deletedEnrollment), enrollmentId.ToString());
        }

        await _enrollmentRepository.DeleteAsync(deletedEnrollment, token);
        await _unitOfWork.SaveChangesAsync(token);
    }
}