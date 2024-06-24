using Ardalis.GuardClauses;
using EduHub.StudentService.Api.Validators.Educator;
using EduHub.StudentService.Application.Services.Dtos.Course;
using EduHub.StudentService.Application.Services.Dtos.Educator;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер преподавателя
/// </summary>
[Route("api/educator")]
[ApiController]
public class EducatorController : ControllerBase
{
    private readonly IEducatorService _educatorService;
    private readonly EducatorCreateDtoValidator _educatorCreateDtoValidator;
    private readonly EducatorUpdateDtoValidator _educatorUpdateDtoValidator;

    public EducatorController(
        IEducatorService educatorService,
        EducatorCreateDtoValidator educatorCreateDtoValidator,
        EducatorUpdateDtoValidator educatorUpdateDtoValidator)
    {
        _educatorService = Guard.Against.Null(educatorService);
        _educatorCreateDtoValidator = educatorCreateDtoValidator;
        _educatorUpdateDtoValidator = educatorUpdateDtoValidator;
    }
    
    /// <summary>
    /// Получение всех преподавателей из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все преподаватели в базе данных.</returns>
    [HttpGet("get-all/list")]
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
    [HttpGet("get-by-id/{id:guid}")]
    public async Task<ActionResult<EducatorDto>> GetByIdAsync(
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
    [HttpGet("get-all-educator-courses/{educatorId:guid}/list")]
    public async Task<ActionResult<EducatorCourseDto[]>> GetAllCourses(
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
    [HttpPost("create")]
    public async Task<ActionResult<CreateEducatorDto>> Create(
        [FromBody] CreateEducatorDto createEducatorDto,
        CancellationToken cancellationToken)
    {
        await _educatorCreateDtoValidator.ValidateAndThrowAsync(createEducatorDto, cancellationToken);
        
        var addedEducator = await _educatorService.AddAsync(createEducatorDto, cancellationToken);
        return Created(nameof(Create), addedEducator);
    }
    
    /// <summary>
    /// Обновление преподавателя в базе
    /// </summary>
    /// <param name="updateEducatorDto">Данные для обновления преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный преподаватель.</returns>
    [HttpPut("update")]
    public async Task<ActionResult<UpdateEducatorDto>> Update(
        [FromBody] UpdateEducatorDto updateEducatorDto,
        CancellationToken cancellationToken)
    {
        await _educatorUpdateDtoValidator.ValidateAndThrowAsync(updateEducatorDto, cancellationToken);
        
        var updatedEducator = await _educatorService.UpdateAsync(updateEducatorDto, cancellationToken);
        return Ok(updatedEducator);
    }
    
    /// <summary>
    /// Удаление преподавателя из базы данных
    /// </summary>
    /// <param name="id">Идентификатор преподавателя.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _educatorService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}