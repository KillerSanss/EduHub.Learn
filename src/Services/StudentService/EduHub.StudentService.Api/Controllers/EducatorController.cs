using EduHub.StudentService.Application.Services.Dtos.Educator;
using EduHub.StudentService.Application.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер преподавателя
/// </summary>
[Route("[controller]")]
[ApiController]
public class EducatorController : ControllerBase
{
    private readonly EducatorService _educatorService;

    public EducatorController(
        EducatorService educatorService)
    {
        _educatorService = educatorService;
    }
    
    /// <summary>
    /// Получение всех преподавателей из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все преподаватели в базе данных.</returns>
    [HttpGet("get_all_educators")]
    public async Task<IActionResult> GetAllAsync(
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
    [HttpGet("get_by_id_educator")]
    public async Task<IActionResult> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var educator = await _educatorService.GetByIdAsync(id, cancellationToken);
        return Ok(educator);
    }

    /// <summary>
    /// Получение всех курсов преподавателя
    /// </summary>
    /// <param name="educatorId">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все курсы преподавателя.</returns>
    [HttpGet("get_educator_courses")]
    public async Task<IActionResult> GetAllCourses(
        Guid educatorId, CancellationToken cancellationToken)
    {
        var courses = await _educatorService.GetAllCourses(educatorId, cancellationToken);
        return Ok(courses);
    }
    
    /// <summary>
    /// Добавление преподавателя в базу
    /// </summary>
    /// <param name="createEducatorDto">Данные для создания преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный преподавателя.</returns>
    [HttpPost("create_educator")]
    public async Task<IActionResult> Create(
        [FromBody] CreateEducatorDto createEducatorDto,
        CancellationToken cancellationToken)
    {
        var addedEducator = await _educatorService.AddAsync(createEducatorDto, cancellationToken);
        return Ok(addedEducator);
    }
    
    /// <summary>
    /// Обновление преподавателя в базе
    /// </summary>
    /// <param name="updateEducatorDto">Данные для обновления преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    [HttpPut("update_educator")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateEducatorDto updateEducatorDto,
        CancellationToken cancellationToken)
    {
        var updatedEducator = await _educatorService.UpdateAsync(updateEducatorDto, cancellationToken);
        return Ok(updatedEducator);
    }
    
    /// <summary>
    /// Удаление преподавателя из базы данных
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("delete_educator")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _educatorService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}