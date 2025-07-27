namespace music_api_v2.Models;

// Todo add most common genre, artist
public class BulkStatisticsResponse
{
    public required int NumberOfArtists { get; set; }
    public required int NumberOfAlbums { get; set; }
    public required int NumberOfGenres { get; set; }
    public required string ModalArtist { get; set; }
    public required string ModalGenre { get; set; }
}