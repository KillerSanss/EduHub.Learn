using Microsoft.AspNetCore.Mvc;

namespace EduHub.StudentService.Api.Controllers;

/// <summary>
/// Контроллер ping
/// </summary>
[Route("[controller]")]
[ApiController]
public class PingController : ControllerBase
{
    /// <summary>
    /// Возвращение pong
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public IActionResult Pong()
    {
        return Ok("pong");
    }
}