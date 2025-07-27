namespace music_api_v2.Models;

// Todo add most common genre, artist
public class BulkStatisticsResponse
{
    public required int numArtists { get; set; }
    public required int numAlbums { get; set; }
    public required int numGenres { get; set; }
}