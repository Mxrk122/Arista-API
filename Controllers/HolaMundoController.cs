using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HolaMundoController : ControllerBase
{
    [HttpGet("hi")]
    public IActionResult GetHolaMundo()
    {
        return Ok("Hola Mundo");
    }
}

