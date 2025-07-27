using Microsoft.AspNetCore.Mvc;
using music_api_v2.Services;

namespace music_api_v2.Controllers;

public class AlbumsController(IAlbumService albumService) : ControllerBase
{   
    [HttpGet]
    [Route("/api/albums")]
    public async Task<IActionResult> GetAlbums()
    {
        var albums = await albumService.HandleGetAllAlbumRows();
        return Ok(albums);
    }
}