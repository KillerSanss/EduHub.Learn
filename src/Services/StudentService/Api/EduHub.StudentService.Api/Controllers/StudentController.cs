using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Dtos.Student;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер студента
/// </summary>
[Route("api/students")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly IEnrollmentService _enrollmentService;

    public StudentController(
        IStudentService studentService,
        IEnrollmentService enrollmentService)
    {
        _studentService = Guard.Against.Null(studentService);
        _enrollmentService = Guard.Against.Null(enrollmentService);
    }
    
    /// <summary>
    /// Получение всех студентов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все студенты в базе данных.</returns>
    [HttpGet]
    public async Task<ActionResult<StudentDto[]>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var students = await _studentService.GetAllAsync(cancellationToken);
        return Ok(students);
    }
    
    /// <summary>
    /// Получение студента по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный студент.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<StudentDto>> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var student = await _studentService.GetByIdAsync(id, cancellationToken);
        return Ok(student);
    }
    
    /// <summary>
    /// Добавление студента
    /// </summary>
    /// <param name="createStudentDto">Данные для создания студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный студент.</returns>
    [HttpPost]
    [Consumes("multipart/form-data")]
    public async Task<ActionResult<UpsertStudentDto>> Create(
        [FromForm] UpsertStudentDto createStudentDto,
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        var addedStudent = await _studentService.AddAsync(createStudentDto, file, cancellationToken);
        return Created(nameof(Create), addedStudent);
    }
    
    /// <summary>
    /// Обновление студента
    /// </summary>
    /// <param name="updateStudentDto">Данные для обновления студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpsertStudentDto>> Update(
        [FromRoute] Guid id,
        [FromForm] UpsertStudentDto updateStudentDto,
        [FromForm] IFormFile file,
        CancellationToken cancellationToken)
    {
        var updatedStudent = await _studentService.UpdateAsync(id, updateStudentDto, file, cancellationToken);
        return Ok(updatedStudent);
    }

    /// <summary>
    /// Удаление студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _studentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
    
    /// <summary>
    /// Получение всех зачислений студента
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех зачислений студента.</returns>
    [HttpGet("{id:guid}/enrollments")]
    public async Task<ActionResult<EnrollmentOfStudentDto[]>> GetStudentEnrollments(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var enrollments = await _enrollmentService.GetStudentEnrollmentsAsync(id, cancellationToken);
        return Ok(enrollments);
    }
}