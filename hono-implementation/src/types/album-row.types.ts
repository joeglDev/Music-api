export interface AlbumRow {
  Catalog: string;
  Artist: string;
  Title: string;
  Label: string;
  Format: string;
  Rating: string;
  Released: number | null;
  ReleaseId: string;
  CollectionFolder: string;
  DateAdded: Date | null; // TODO: Upgrade node and use Temporal date
  MediaCondition: string;
  SleeveCondition: string;
  Owner: string;
  Genre: string;
}
