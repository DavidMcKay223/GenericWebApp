using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenericWebApp.DTO.Music
{
    public class Album
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Artist Name is required")]
        [StringLength(500, ErrorMessage = "Artist Name cannot exceed 500 characters")]
        public string ArtistName { get; set; }

        public List<CD> CDList { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (String.IsNullOrEmpty(ArtistName))
            {
                errorList.Add(new Error { Code = "DTO.Invalid", Message = "Artist Name is required" });
            }

            if (CDList != null)
            {
                foreach (var cd in CDList)
                {
                    cd.IsValid(errorList);
                }
            }

            return errorList.Count == 0;
        }
    }

    public class CD
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "CD Name is required")]
        [StringLength(500, ErrorMessage = "CD Name cannot exceed 500 characters")]
        public string Name { get; set; }

        public int? Album_ID { get; set; }
        public int? Genre_ID { get; set; }
        public List<Track> TrackList { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (String.IsNullOrEmpty(Name))
            {
                errorList.Add(new Error { Code = "DTO.Invalid", Message = "CD Name is required" });
            }

            if (TrackList != null)
            {
                foreach (var track in TrackList)
                {
                    track.IsValid(errorList);
                }
            }

            return errorList.Count == 0;
        }
    }

    public class Track
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Track Number is required")]
        public int Number { get; set; }

        [Required(ErrorMessage = "Track Title is required")]
        [StringLength(500, ErrorMessage = "Track Title cannot exceed 500 characters")]
        public string Title { get; set; }

        public int CD_ID { get; set; }

        [Required(ErrorMessage = "Track Length is required")]
        public TimeSpan Length { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (String.IsNullOrEmpty(Title))
            {
                errorList.Add(new Error { Code = "DTO.Invalid", Message = "Track Title is required" });
            }

            if (Length == TimeSpan.Zero)
            {
                errorList.Add(new Error { Code = "DTO.Invalid", Message = "Track Length is required" });
            }

            return errorList.Count == 0;
        }
    }

    public class Genre
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
