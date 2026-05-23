namespace music_api_v2.Models;
public record AlbumRow(
    string Catalog,
    string Artist,
    string Title,
    string Label,
    string Format,
    string Rating,
    int? Released,
    string ReleaseId,
    string CollectionFolder,
    DateTime? DateAdded,
    string MediaCondition,
    string SleeveCondition,
    string Owner,
    string Genre
);