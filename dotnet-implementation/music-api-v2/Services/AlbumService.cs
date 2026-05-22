using music_api_v2.Database;
using music_api_v2.Models;

namespace music_api_v2.Services;

public interface IAlbumService
{
    public Task<AlbumRow[]> HandleAllAlbumRows();
    public Task<BulkStatisticsResponse> HandleBulkStatistics(AlbumOwners owner);
}

public class AlbumService(DatabaseService databaseService) :  IAlbumService
{
    public async Task<AlbumRow[]> HandleAllAlbumRows()
    {
        var albums = await databaseService.SelectAllAlbums();
        return albums;
    }
    
    public async Task<BulkStatisticsResponse> HandleBulkStatistics(AlbumOwners owner)
    {
        var albums = await databaseService.SelectAllAlbums();
        var filteredAlbums = owner == AlbumOwners.All ? albums : albums.Where(album => album.Owner == owner.ToString()).ToArray();
        
        var uniqueArtistsCount = filteredAlbums.Select(x => x.Artist).Distinct().Count();
        var uniqueGenresCount = filteredAlbums.Select(x => x.Genre).Distinct().Count();
        var uniqueAlbumsCount = filteredAlbums.Length;


        var modalArtist = filteredAlbums
            .GroupBy(x => x.Artist)
            .OrderByDescending(x => x.Count())
            .First().Key;

        var modalGenre = filteredAlbums
            .GroupBy(x => x.Genre)
            .OrderByDescending(x => x.Count())
            .First().Key;
        
        return new BulkStatisticsResponse {
            NumberOfAlbums = uniqueAlbumsCount, 
            NumberOfArtists = uniqueArtistsCount, 
            NumberOfGenres = uniqueGenresCount,
            ModalArtist = modalArtist,
            ModalGenre = modalGenre
        };
    }
}