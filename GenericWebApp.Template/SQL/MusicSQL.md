# Generic SQL Scripts:

```
--Display Data to Feed to AI for Unit Test Cases
SELECT 
    --album.ID AS AlbumID,
    album.ArtistName,
    --cd.ID AS CDID,
    cd.Name AS CDName,
    --cd.Genre_ID,
    genre.Description AS GenreDescription,
    --track.ID AS TrackID,
    track.Number AS TrackNumber,
    track.Title AS TrackTitle,
    track.Length AS TrackLength
FROM 
    [GenericWebApp].[dbo].[Music_Album] album
    LEFT JOIN [GenericWebApp].[dbo].[Music_CD] cd ON album.ID = cd.Album_ID
    LEFT JOIN [GenericWebApp].[dbo].[Music_Genre] genre ON cd.Genre_ID = genre.ID
    LEFT JOIN [GenericWebApp].[dbo].[Music_Track] track ON cd.ID = track.CD_ID
ORDER BY 
    album.ID, cd.ID, track.ID;
```
