using AutoMapper;
using EduHub.StudentService.Application.Services.Exceptions;
using EduHub.StudentService.Application.Services.Repositories;
using Eduhub.StudentService.Domain.Entities;

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

    public EnrollmentService(IEnrollmentRepository enrollmentRepository, ICourseRepository courseRepository, IStudentRepository studentRepository, IMapper mapper)
    {
        _enrollmentRepository = enrollmentRepository;
        _courseRepository = courseRepository;
        _studentRepository = studentRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Зачисления студента на выбранный курс
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="courseId">Идентификатор курса.</param>
    /// <param name="startDate">Дата зачисления.</param>
    /// <returns>Новое зачисление.</returns>
    public async Task<Enrollment> AsyncEnrollStudent(Guid studentId, Guid courseId, DateTime startDate)
    {
        var existingStudent = await _studentRepository.GetStudentById(studentId);
        if (existingStudent == null)
        {
            throw new EntityNotFoundException<Guid>(studentId, "Student does not exist");
        }

        var existingCourse = await _courseRepository.GetCourseById(courseId);
        if (existingCourse == null)
        {
            throw new EntityNotFoundException<Guid>(courseId, "Course does not exist");
        }

        await _enrollmentRepository.EnrollStudent(studentId, courseId, startDate);

        return _mapper.Map<Enrollment>(_enrollmentRepository.EnrollStudent(studentId, courseId, startDate));
    }

    /// <summary>
    /// Выбор зачислений студента
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <returns>Список зачислений студента.</returns>
    public async Task<List<Enrollment>> AsyncGetStudentEnrollments(Guid studentId)
    {
        var allStudentEnrollments = await _enrollmentRepository.GetStudentEnrollments(studentId);
        return _mapper.Map<List<Enrollment>>(allStudentEnrollments);
    }

    /// <summary>
    /// Выбор всех зачислений
    /// </summary>
    /// <returns>Список всех зачислений.</returns>
    public async Task<List<Enrollment>> AsyncGetAllEnrollments()
    {
        var allEnrollments = await _enrollmentRepository.GetAllEnrollments();

        return _mapper.Map<List<Enrollment>>(allEnrollments);
    }

    /// <summary>
    /// Удаление зачисления
    /// </summary>
    /// <param name="enrollmentId">Идентификатор зачисления.</param>
    /// <returns>Удаленное зачисление.</returns>
    public async Task<Enrollment> AsyncDeleteEnrollment(Guid enrollmentId)
    {
        var deletedEnrollment = await _enrollmentRepository.GetEnrollmentById(enrollmentId);
        if (deletedEnrollment == null)
        {
            throw new EntityNotFoundException<Guid>(enrollmentId, "Enrollment does not exist");
        }

        await _enrollmentRepository.DeleteEnrollment(enrollmentId);

        return deletedEnrollment;
    }
}