using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер курса
/// </summary>
[Route("[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly CourseService _courseService;

    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }
    
    /// <summary>
    /// Получение всех курсов из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все курсы в базе данных.</returns>
    [HttpGet("get_all_courses")]
    public async Task<IActionResult> GetAllAsync(
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
    [HttpGet("get_by_id_course")]
    public async Task<IActionResult> GetByIdAsync(
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
    [HttpPost("create_course")]
    public async Task<IActionResult> Create(
        [FromBody] CreateCourseDto createCourseDto,
        CancellationToken cancellationToken)
    {
        var addedCourse = await _courseService.AddAsync(createCourseDto, cancellationToken);
        return Ok(addedCourse);
    }
    
    /// <summary>
    /// Обновление курса в базе
    /// </summary>
    /// <param name="updateCourseDto">Данные для обновления курса.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный курс.</returns>
    [HttpPut("update_course")]
    public async Task<IActionResult> Update(
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
    [HttpDelete("delete_course")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _courseService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}
