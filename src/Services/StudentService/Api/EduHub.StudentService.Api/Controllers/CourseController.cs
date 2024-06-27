using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер курса
/// </summary>
[Route("api/courses")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = Guard.Against.Null(courseService);
    }
    
    /// <summary>
    /// Получение всех курсов
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все курсы в базе данных.</returns>
    [HttpGet]
    public async Task<ActionResult<CourseDto[]>> GetAllAsync(
        CancellationToken cancellationToken)
    {
        var courses = await _courseService.GetAllAsync(cancellationToken);
        return Ok(courses);
    }
    
    /// <summary>
    /// Получение курса по идентификатору
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Выбранный курс.</returns>
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<CourseDto>> GetByIdAsync(
        [FromRoute] Guid id,
        CancellationToken cancellationToken)
    {
        var course = await _courseService.GetByIdAsync(id, cancellationToken);
        return Ok(course);
    }
    
    /// <summary>
    /// Добавление курса
    /// </summary>
    /// <param name="createCourseDto">Данные для создания курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный курс.</returns>
    [HttpPost]
    public async Task<ActionResult<UpsertCourseDto>> Create(
        [FromBody] UpsertCourseDto createCourseDto,
        CancellationToken cancellationToken)
    {
        var addedCourse = await _courseService.AddAsync(createCourseDto, cancellationToken);
        return Created(nameof(Create), addedCourse);
    }
    
    /// <summary>
    /// Обновление курса
    /// </summary>
    /// <param name="updateCourseDto">Данные для обновления курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpsertCourseDto>> Update(
        [FromRoute] Guid id,
        [FromBody] UpsertCourseDto updateCourseDto,
        CancellationToken cancellationToken)
    {
        var updatedStudent = await _courseService.UpdateAsync(id, updateCourseDto, cancellationToken);
        return Ok(updatedStudent);
    }

    /// <summary>
    /// Удаление курса
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await _courseService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
