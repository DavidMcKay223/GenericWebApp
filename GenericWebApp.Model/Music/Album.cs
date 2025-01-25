using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Music
{
    [Table("Music_Album")]
    public class Album
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string ArtistName { get; set; }

        public List<CD> CDList { get; set; }

        public static DTO.Music.Album ParseDTO(Model.Music.Album album)
        {
            if (album == null) return null;

            DTO.Music.Album dto = new DTO.Music.Album
            {
                ID = album.ID,
                ArtistName = album.ArtistName,
                CDList = album.CDList?.Select(cd => CD.ParseDTO(cd)).ToList()
            };

            return dto;
        }

        public static Model.Music.Album ParseModel(DTO.Music.Album dto)
        {
            if (dto == null) return null;

            Model.Music.Album album = new Model.Music.Album
            {
                ID = dto.ID ?? 0,
                ArtistName = dto.ArtistName,
                CDList = dto.CDList?.Select(cd => CD.ParseModel(cd)).ToList()
            };

            return album;
        }
    }

    [Table("Music_CD")]
    public class CD
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }

        public int? Album_ID { get; set; }

        public int? Genre_ID { get; set; }

        public List<Track> TrackList { get; set; }
        public Album Album { get; set; }

        public static DTO.Music.CD ParseDTO(Model.Music.CD cd)
        {
            if (cd == null) return null;

            DTO.Music.CD dto = new DTO.Music.CD
            {
                ID = cd.ID,
                Name = cd.Name,
                Album_ID = cd.Album_ID,
                Genre_ID = cd.Genre_ID,
                TrackList = cd.TrackList?.Select(track => Track.ParseDTO(track)).ToList()
            };

            return dto;
        }

        public static Model.Music.CD ParseModel(DTO.Music.CD dto)
        {
            if (dto == null) return null;

            Model.Music.CD cd = new Model.Music.CD
            {
                ID = dto.ID,
                Name = dto.Name,
                Album_ID = dto.Album_ID,
                Genre_ID = dto.Genre_ID,
                TrackList = dto.TrackList?.Select(track => Track.ParseModel(track)).ToList()
            };

            return cd;
        }
    }

    [Table("Music_Track")]
    public class Track
    {
        [Key]
        public int ID { get; set; }

        public int Number { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public int CD_ID { get; set; }

        public TimeSpan Length { get; set; }
        public CD CD { get; set; }

        public static DTO.Music.Track ParseDTO(Model.Music.Track track)
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

        public static Model.Music.Track ParseModel(DTO.Music.Track dto)
        {
            if (dto == null) return null;

            Model.Music.Track track = new Model.Music.Track
            {
                ID = dto.ID,
                Number = dto.Number,
                Title = dto.Title,
                CD_ID = dto.CD_ID,
                Length = dto.Length
            };

            return track;
        }
    }

    [Table("Music_Genre")]
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public static DTO.Music.Genre ParseDTO(Model.Music.Genre genre)
        {
            if (genre == null) return null;

            DTO.Music.Genre dto = new DTO.Music.Genre
            {
                ID = genre.ID,
                Description = genre.Description
            };

            return dto;
        }

        public static Model.Music.Genre ParseModel(DTO.Music.Genre dto)
        {
            if (dto == null) return null;

            Model.Music.Genre genre = new Model.Music.Genre
            {
                ID = dto.ID,
                Description = dto.Description
            };

            return genre;
        }
    }
}
