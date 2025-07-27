using Microsoft.AspNetCore.Mvc;

namespace music_api_v2.Controllers;

public class PingController : ControllerBase
{   
    /// <summary>
    /// Returns string Pong if server is extant
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("api/ping")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<string> Ping()
    {
        return Ok("Pong");
    }
}