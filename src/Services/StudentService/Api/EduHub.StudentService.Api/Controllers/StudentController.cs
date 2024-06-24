using Ardalis.GuardClauses;
using EduHub.StudentService.Api.Validators.Student;
using EduHub.StudentService.Application.Services.Dtos.Student;
using EduHub.StudentService.Application.Services.Interfaces.Services;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер студента
/// </summary>
[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IStudentService _studentService;
    private readonly StudentCreateDtoValidator _studentCreateDtoValidator;
    private readonly StudentUpdateDtoValidator _studentUpdateDtoValidator;

    public StudentController(
        IStudentService studentService,
        StudentCreateDtoValidator studentCreateDtoValidator,
        StudentUpdateDtoValidator studentUpdateDtoValidator)
    {
        _studentService = Guard.Against.Null(studentService);
        _studentCreateDtoValidator = studentCreateDtoValidator;
        _studentUpdateDtoValidator = studentUpdateDtoValidator;
    }
    
    /// <summary>
    /// Получение всех студентов из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все студенты в базе данных.</returns>
    [HttpGet("get-all/list")]
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
    [HttpGet("get-by-id/{id:guid}")]
    public async Task<ActionResult<StudentDto>> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken)
    {
        var student = await _studentService.GetByIdAsync(id, cancellationToken);
        return Ok(student);
    }
    
    /// <summary>
    /// Добавление студента в базу
    /// </summary>
    /// <param name="createStudentDto">Данные для создания студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Добавленный студент.</returns>
    [HttpPost("create")]
    public async Task<ActionResult<CreateStudentDto>> Create(
        [FromBody] CreateStudentDto createStudentDto,
        CancellationToken cancellationToken)
    {
        await _studentCreateDtoValidator.ValidateAndThrowAsync(createStudentDto, cancellationToken);
        
        var addedStudent = await _studentService.AddAsync(createStudentDto, cancellationToken);
        return Created(nameof(Create), addedStudent);
    }
    
    /// <summary>
    /// Обновление студента в базе
    /// </summary>
    /// <param name="updateStudentDto">Данные для обновления студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    [HttpPut("update")]
    public async Task<ActionResult<UpdateStudentDto>> Update(
        [FromBody] UpdateStudentDto updateStudentDto,
        CancellationToken cancellationToken)
    {
        await _studentUpdateDtoValidator.ValidateAndThrowAsync(updateStudentDto, cancellationToken);
        
        var updatedStudent = await _studentService.UpdateAsync(updateStudentDto, cancellationToken);
        return Ok(updatedStudent);
    }

    /// <summary>
    /// Удаление студента из базы данных
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("delete/{id:guid}")]
    public async Task<ActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _studentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}