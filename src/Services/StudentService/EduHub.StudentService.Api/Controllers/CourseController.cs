using Ardalis.GuardClauses;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер курса
/// </summary>
[Route("[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = Guard.Against.Null(courseService);
    }
    
    /// <summary>
    /// Получение всех курсов из базы данных
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
        Guid id,
        CancellationToken cancellationToken)
    {
        var course = await _courseService.GetByIdAsync(id, cancellationToken);
        return Ok(course);
    }
    
    /// <summary>
    /// Добавление курса в базу
    /// </summary>
    /// <param name="createCourseDto">Данные для создания курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный курс.</returns>
    [HttpPost]
    public async Task<ActionResult<CreateCourseDto>> Create(
        [FromBody] CreateCourseDto createCourseDto,
        CancellationToken cancellationToken)
    {
        var addedCourse = await _courseService.AddAsync(createCourseDto, cancellationToken);
        return Created(nameof(Create), addedCourse);
    }
    
    /// <summary>
    /// Обновление курса в базе
    /// </summary>
    /// <param name="updateCourseDto">Данные для обновления курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    [HttpPut("{id:guid}")]
    public async Task<ActionResult<UpdateCourseDto>> Update(
        [FromBody] UpdateCourseDto updateCourseDto,
        CancellationToken cancellationToken)
    {
        var updatedStudent = await _courseService.UpdateAsync(updateCourseDto, cancellationToken);
        return Ok(updatedStudent);
    }

    /// <summary>
    /// Удаление курса из базы данных
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _courseService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
