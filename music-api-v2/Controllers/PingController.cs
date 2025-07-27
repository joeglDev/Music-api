using Microsoft.AspNetCore.Mvc;

namespace music_api_v2.Controllers;

public class PingController : ControllerBase
{   
    [HttpGet]
    [Route("api/ping")]
    public IActionResult Ping()
    {
        return Ok("Pong");
    }
}