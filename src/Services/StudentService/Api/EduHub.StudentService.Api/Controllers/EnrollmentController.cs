using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Dtos.Enrollment;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер зачисления
/// </summary>
[Route("api/enrollment")]
[ApiController]
public class EnrollmentController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = Guard.Against.Null(enrollmentService);
    }
    
    /// <summary>
    /// Получение всех зачислений из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все зачисления в базе данных.</returns>
    [HttpGet("list")]
    public async Task<ActionResult<EnrollmentDto[]>> GetAllAsync(
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
    [HttpGet("{studentId:guid}/list")]
    public async Task<ActionResult<StudentEnrollmentDto[]>> GetStudentEnrollments(
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
    [HttpPost]
    public async Task<ActionResult<CreateEnrollmentDto>> Create(
        [FromBody] CreateEnrollmentDto createEnrollmentDto,
        CancellationToken cancellationToken)
    {
        var addedEnrollment = await _enrollmentService.AddAsync(createEnrollmentDto, cancellationToken);
        return Created(nameof(Create), addedEnrollment);
    }
    
    /// <summary>
    /// Удаление зачисления из базы данных
    /// </summary>
    /// <param name="id">Идентификатор зачисления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _enrollmentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}