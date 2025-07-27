using Microsoft.AspNetCore.Mvc;
using music_api_v2.Models;
using music_api_v2.Services;

namespace music_api_v2.Controllers;

public class AlbumsController(IAlbumService albumService) : ControllerBase
{   
    /// <summary>
    /// Gets a list of albums
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("/api/albums")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<AlbumRow[]>> GetAlbums()
    {
        var albums = await albumService.HandleAllAlbumRows();
        return Ok(albums);
    }

    /// <summary>
    /// Returns statistics on the album collection
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [Route("api/albums/bulk-statistics")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<BulkStatisticsResponse>> GetBulkStatistics()
    {
        var bulkStatistics = await albumService.HandleBulkStatistics();
        return Ok(bulkStatistics);
    }
}