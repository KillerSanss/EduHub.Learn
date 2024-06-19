using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер зачисления
/// </summary>
[Route("[controller]")]
[ApiController]
public class EnrollmentController : ControllerBase
{
    private readonly EnrollmentService _enrollmentService;

    public EnrollmentController(
        EnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }
    
    /// <summary>
    /// Получение всех зачислений из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все зачисления в базе данных.</returns>
    [HttpGet("get_all_enrollments")]
    public async Task<IActionResult> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var enrollments = await _enrollmentService.GetAllAsync(cancellationToken);
        return Ok(enrollments);
    }
    
    /// <summary>
    /// Получение всех зачислений студента из базы
    /// </summary>
    /// <param name="studentId">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Список всех зачислений студента.</returns>
    [HttpGet("get_student_enrollments")]
    public async Task<IActionResult> GetStudentEnrollments(
        Guid studentId,
        CancellationToken cancellationToken)
    {
        var enrollments = await _enrollmentService.GetStudentEnrollmentsAsync(studentId, cancellationToken);
        return Ok(enrollments);
    }
    
    /// <summary>
    /// Добавление зачисления в базу
    /// </summary>
    /// <param name="createEnrollmentDto">Данные для создания зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленное зачисление.</returns>
    [HttpPost("create_enrollment")]
    public async Task<IActionResult> Create(
        [FromBody] CreateEnrollmentDto createEnrollmentDto,
        CancellationToken cancellationToken)
    {
        var addedEnrollment = await _enrollmentService.AddAsync(createEnrollmentDto, cancellationToken);
        return Ok(addedEnrollment);
    }
    
    /// <summary>
    /// Удаление зачисления из базы данных
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("delete_enrollment")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _enrollmentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}