using Ardalis.GuardClauses;
using EduHub.StudentService.Api.Validators.Course;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер курса
/// </summary>
[Route("api/course")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;
    private readonly CourseCreateDtoValidator _courseCreateDtoValidator;
    private readonly CourseUpdateDtoValidator _courseUpdateDtoValidator;

    public CourseController(
        ICourseService courseService,
        CourseCreateDtoValidator courseCreateDtoValidator,
        CourseUpdateDtoValidator courseUpdateDtoValidator)
    {
        _courseService = Guard.Against.Null(courseService);
        _courseCreateDtoValidator = courseCreateDtoValidator;
        _courseUpdateDtoValidator = courseUpdateDtoValidator;
    }
    
    /// <summary>
    /// Получение всех курсов из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все курсы в базе данных.</returns>
    [HttpGet("get-all/list")]
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
    [HttpGet("get-by-id/{id:guid}")]
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
    [HttpPost("create")]
    public async Task<ActionResult<CreateCourseDto>> Create(
        [FromBody] CreateCourseDto createCourseDto,
        CancellationToken cancellationToken)
    {
        await _courseCreateDtoValidator.ValidateAndThrowAsync(createCourseDto, cancellationToken);
        
        var addedCourse = await _courseService.AddAsync(createCourseDto, cancellationToken);
        return Created(nameof(Create), addedCourse);
    }
    
    /// <summary>
    /// Обновление курса в базе
    /// </summary>
    /// <param name="updateCourseDto">Данные для обновления курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    [HttpPut("update")]
    public async Task<ActionResult<UpdateCourseDto>> Update(
        [FromBody] UpdateCourseDto updateCourseDto,
        CancellationToken cancellationToken)
    {
        await _courseUpdateDtoValidator.ValidateAndThrowAsync(updateCourseDto, cancellationToken);
        
        var updatedStudent = await _courseService.UpdateAsync(updateCourseDto, cancellationToken);
        return Ok(updatedStudent);
    }

    /// <summary>
    /// Удаление курса из базы данных
    /// </summary>
    /// <param name="id">Идентификатор курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _courseService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
