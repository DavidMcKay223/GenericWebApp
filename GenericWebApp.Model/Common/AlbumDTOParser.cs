using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class AlbumDTOParser
    {
        public static DTO.Music.Album? ParseDTO(Model.Music.Album album)
        {
            if (album == null) return null;

            DTO.Music.Album dto = new DTO.Music.Album
            {
                ID = album.ID,
                ArtistName = album.ArtistName,
                CDList = album.CDList?.Select(ParseDTO).Where(cd => cd != null).Cast<DTO.Music.CD>().ToList()
            };

            return dto;
        }

        public static DTO.Music.CD? ParseDTO(Model.Music.CD cd)
        {
            if (cd == null) return null;

            DTO.Music.CD dto = new DTO.Music.CD
            {
                ID = cd.ID,
                Name = cd.Name,
                Album_ID = cd.Album_ID,
                Genre_ID = cd.Genre_ID,
                TrackList = cd.TrackList?.Select(track => ParseDTO(track)).Where(track => track != null).Cast<DTO.Music.Track>().ToList()
            };

            return dto;
        }

        public static DTO.Music.Track? ParseDTO(Model.Music.Track track)
        {
            if (track == null) return null;

            DTO.Music.Track dto = new DTO.Music.Track
            {
                ID = track.ID,
                Number = track.Number,
                Title = track.Title,
                CD_ID = track.CD_ID,
                Length = track.Length
            };

            return dto;
        }

        public static DTO.Music.Genre? ParseDTO(Model.Music.Genre genre)
        {
            if (genre == null) return null;

            DTO.Music.Genre dto = new DTO.Music.Genre
            {
                ID = genre.ID,
                Description = genre.Description
            };

            return dto;
        }
    }
}
