using System.Globalization;
using music_api_v2.Models;

namespace music_api_v2.Utils;

public class FileIoLogic
{
    public IEnumerable<string[]> ReadCsvFile(string filePath)
    {
        Console.WriteLine("Reading file: " + filePath);

        var lines = File.ReadAllLines(filePath);
        var values =
            lines.Skip(1)
                .Select(l =>
                    l.Split('@')); // csv must use a @ delineator not , as discogs inserts lots of random , in strings

        return values;
    }

    public AlbumRow[] ConvertRowsToAlbumRows(IEnumerable<string[]> rows)
    {
        return rows.Select(v => new AlbumRow(
            v[0],
            v[1],
            v[2],
            v[3],
            v[4],
            v[5],
            int.TryParse(v[6], out var result) ? result : null,
            v[7],
            v[8],
            DateTime.TryParseExact(
                v[9],
                "yyyy-MM-dd HH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out var parsedDateTime)
                ? parsedDateTime
                : null,
            v[10],
            v[11],
            v[12],
            v[13]
        )).ToArray();
    }
}