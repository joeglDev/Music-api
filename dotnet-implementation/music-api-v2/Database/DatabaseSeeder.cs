using Dapper;
using music_api_v2.Models;
using music_api_v2.Utils;
using Npgsql;

namespace  music_api_v2.Database;


public class DatabaseSeeder : InitialiseDatabase
{
    public async Task SeedDatabase()
    {
        var conn = GetIndividualConnection();

        await CreateTable(conn);
        await PopulateTable(conn);
    }

    private async Task CreateTable(NpgsqlConnection conn)
    {
        Console.WriteLine("Creating tables...");
        var createTableQuery = @"CREATE TABLE IF NOT EXISTS albums (
    Catalog VARCHAR(75),
    Artist TEXT,
    Title TEXT,
    Label VARCHAR(75),
    Format VARCHAR(75),
    Rating VARCHAR(75),
    Released INTEGER,
    ReleaseId TEXT,
    CollectionFolder VARCHAR(75),
    DateAdded TIMESTAMP,
    MediaCondition VARCHAR(75),
    sleeveCondition VARCHAR(75),
    Owner VARCHAR(75),
    Genre VARCHAR(75)
);";

        await conn.ExecuteAsync(createTableQuery);
    }

    private async Task PopulateTable(NpgsqlConnection conn)
    {
        Console.WriteLine("Populating tables...");

        var csvPath = Directory.GetCurrentDirectory() + "/Database/Data/seed-data.csv";

        var fileIoLogic = new FileIoLogic();
        var csvData = fileIoLogic.ReadCsvFile(csvPath);
        var albumRows = fileIoLogic.ConvertRowsToAlbumRows(csvData);

        var insertDataSql = @"
        INSERT INTO albums (
    catalog, artist, title, label, format, rating,
    released, releaseId, collectionFolder, dateAdded,
    mediaCondition, sleeveCondition, owner, genre
    )
        SELECT 
    @catalog, @artist, @title, @label, @Format, @rating,
    @released, @releaseId, @collectionFolder, @dateAdded,
    @MediaCondition, @sleeveCondition, @owner, @Genre
        WHERE NOT EXISTS (
            SELECT 1 FROM albums WHERE title = @title
                );";

        await conn.ExecuteAsync(insertDataSql, albumRows);
    }
}