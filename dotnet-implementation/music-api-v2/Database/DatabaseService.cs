using Dapper;
using music_api_v2.Models;

namespace  music_api_v2.Database;

public class DatabaseService : InitialiseDatabase
{
    public async Task<AlbumRow[]> SelectAllAlbums()
    {
        var conn = GetIndividualConnection();
        var sql = "SELECT * FROM albums";
        var albumRowsFromDb = await conn.QueryAsync<AlbumRow>(sql);

        return albumRowsFromDb.ToArray();
    }
}