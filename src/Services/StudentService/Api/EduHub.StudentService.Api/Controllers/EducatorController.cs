using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер преподавателя
/// </summary>
[Route("api/educators")]
[ApiController]
public class EducatorController : ControllerBase
{
    private readonly IEducatorService _educatorService;

    public EducatorController(IEducatorService educatorService)
    {
        _educatorService = Guard.Against.Null(educatorService);
    }
    
    /// <summary>
    /// Получение всех преподавателей
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все преподаватели в базе данных.</returns>
    [HttpGet]
    public async Task<ActionResult<EducatorDto[]>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var educators = await _educatorService.GetAllAsync(cancellationToken);
        return Ok(educators);
    }
    
    /// <summary>
    /// Получение преподавателя по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный преподаватель.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<EducatorDto>> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var educator = await _educatorService.GetByIdAsync(id, cancellationToken);
        return Ok(educator);
    }

    /// <summary>
    /// Получение всех курсов преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все курсы преподавателя.</returns>
    [HttpGet("{id:guid}/courses")]
    public async Task<ActionResult<EducatorCourseDto[]>> GetAllCourses(
        Guid id,
        CancellationToken cancellationToken)
    {
        var courses = await _educatorService.GetAllCourses(id, cancellationToken);
        return Ok(courses);
    }
    
    /// <summary>
    /// Добавление преподавателя
    /// </summary>
    /// <param name="createEducatorDto">Данные для создания преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный преподавателя.</returns>
    [HttpPost]
    public async Task<ActionResult<UpsertEducatorDto>> Create(
        [FromBody] UpsertEducatorDto createEducatorDto,
        CancellationToken cancellationToken)
    {
        var addedEducator = await _educatorService.AddAsync(createEducatorDto, cancellationToken);
        return Created(nameof(Create), addedEducator);
    }
    
    /// <summary>
    /// Обновление преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="updateEducatorDto">Данные для обновления преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpsertEducatorDto>> Update(
        [FromRoute] Guid id,
        [FromBody] UpsertEducatorDto updateEducatorDto,
        CancellationToken cancellationToken)
    {
        var updatedEducator = await _educatorService.UpdateAsync(id, updateEducatorDto, cancellationToken);
        return Ok(updatedEducator);
    }
    
    /// <summary>
    /// Удаление преподавателя
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _educatorService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}