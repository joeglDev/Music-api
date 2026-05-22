using System.Text.Json.Serialization;

namespace music_api_v2.Models;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AlbumOwners
{
    All = 0,
    Joe = 1,
    Lvkas = 2,
    Grandad = 3
}