using EduHub.StudentService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер аватаров
/// </summary>
[ApiController]
[Route("api/avatars")]
public class AvatarController : ControllerBase
{
    private readonly FileClient _fileClient;

    public AvatarController(FileClient fileClient)
    {
        _fileClient = fileClient;
    }

    /// <summary>
    /// Получение uri файла по идентификатору (название)
    /// </summary>
    /// <param name="id">Идентификатор (название).</param>
    /// <returns>Uri.</returns>
    [HttpGet("uri/{id}")]
    public async Task<IActionResult> GetFileUri([FromRoute] string id)
    {
        var uri = await _fileClient.GetFileUriAsync(id);
        return Ok(new { Uri = uri });
    }
}