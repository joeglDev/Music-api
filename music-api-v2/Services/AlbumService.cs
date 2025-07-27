using music_api_v2.Database;
using music_api_v2.Models;

namespace music_api_v2.Services;

public interface IAlbumService
{
    public Task<AlbumRow[]> HandleGetAllAlbumRows();
}

public class AlbumService(DatabaseService databaseService) :  IAlbumService
{
    public async Task<AlbumRow[]> HandleGetAllAlbumRows()
    {
        var albums = await databaseService.SelectAllAlbums();
        return albums;
    }
}