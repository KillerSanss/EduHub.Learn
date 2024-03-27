using Ardalis.GuardClauses;
using AutoMapper;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Interfaces.Repositories;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using EduHub.StudentService.Application.Services.Interfaces.UnitOfWork;
using Eduhub.StudentService.Domain.Entities;

namespace EduHub.StudentService.Application.Services.Services;

/// <summary>
/// Сервис зачисления
/// </summary>
public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public EnrollmentService(
        IEnrollmentRepository enrollmentRepository,
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        _enrollmentRepository = Guard.Against.Null(enrollmentRepository);
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

        var enrollment = _mapper.Map<Enrollment>(enrollmentDto);

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
    public async Task<EnrollmentDto[]> GetStudentEnrollmentsAsync(Guid studentId, CancellationToken cancellationToken)
    {
        var studentEnrollments = await _enrollmentRepository.GetStudentEnrollmentsAsync(studentId, cancellationToken);
        return _mapper.Map<EnrollmentDto[]>(studentEnrollments);
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
        var enrollment = await IsExistEnrollmentAsync(id, cancellationToken);

        await _enrollmentRepository.DeleteAsync(enrollment, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    private async Task<Enrollment> IsExistEnrollmentAsync(Guid id, CancellationToken cancellationToken)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id, cancellationToken);
        if (enrollment == null)
        {
            throw new EntityNotFoundException<Enrollment>(nameof(Enrollment.Id), id.ToString());
        }

        return enrollment;
    }
}