using EduHub.StudentService.Application.Services.Dtos.Student;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер студента
/// </summary>
[Route("[controller]")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly Application.Services.Services.StudentService _studentService;

    public StudentController(Application.Services.Services.StudentService studentService)
    {
        _studentService = studentService;
    }
    
    /// <summary>
    /// Получение всех студентов из базы данных
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Все студенты в базе данных.</returns>
    [HttpGet("get_all_students")]
    public async Task<IActionResult> GetAllAsync(
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
    [HttpGet("get_by_id_student")]
    public async Task<IActionResult> GetByIdAsync(
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
    [HttpPost("create_student")]
    public async Task<IActionResult> Create(
        [FromBody] CreateStudentDto createStudentDto,
        CancellationToken cancellationToken)
    {
        var addedStudent = await _studentService.AddAsync(createStudentDto, cancellationToken);
        return Ok(addedStudent);
    }
    
    /// <summary>
    /// Обновление студента в базе
    /// </summary>
    /// <param name="updateStudentDto">Данные для обновления студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленный студент.</returns>
    [HttpPut("update_student")]
    public async Task<IActionResult> Update(
        [FromBody] UpdateStudentDto updateStudentDto,
        CancellationToken cancellationToken)
    {
        var updatedStudent = await _studentService.UpdateAsync(updateStudentDto, cancellationToken);
        return Ok(updatedStudent);
    }

    /// <summary>
    /// Удаление студента из базы данных
    /// </summary>
    /// <param name="id">Идентификатор студента.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    [HttpDelete("delete_student")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        await _studentService.DeleteAsync(id, cancellationToken);
        return NoContent();
    }
}