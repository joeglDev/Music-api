using music_api_v2.Database;
using music_api_v2.Models;

namespace music_api_v2.Services;

public interface IAlbumService
{
    public Task<AlbumRow[]> HandleAllAlbumRows();
    public Task<BulkStatisticsResponse> HandleBulkStatistics();
}

public class AlbumService(DatabaseService databaseService) :  IAlbumService
{
    public async Task<AlbumRow[]> HandleAllAlbumRows()
    {
        var albums = await databaseService.SelectAllAlbums();
        return albums;
    }

    // Todo add most common genre, artist
    public async Task<BulkStatisticsResponse> HandleBulkStatistics()
    {
        var albums = await databaseService.SelectAllAlbums();
        
        var uniqueArtistsCount = albums.Select(x => x.Artist).Distinct().Count();
        var uniqueGenresCount = albums.Select(x => x.Genre).Distinct().Count();
        var uniqueAlbumsCount = albums.Length;
        
        return new BulkStatisticsResponse {numAlbums = uniqueAlbumsCount, numArtists = uniqueArtistsCount, numGenres = uniqueGenresCount};

    }
}