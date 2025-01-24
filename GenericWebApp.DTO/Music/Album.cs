using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;

namespace GenericWebApp.DTO.Music
{
    public class Album
    {
        public int? ID { get; set; }
        public string ArtistName { get; set; }
        public List<CD> CDList { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (string.IsNullOrEmpty(ArtistName))
            {
                errorList.Add(new Error { Code = "ArtistNameRequired", Message = "Artist name is required." });
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
        public string Name { get; set; }
        public int? Album_ID { get; set; }
        public int? Genre_ID { get; set; }
        public List<Track> TrackList { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (string.IsNullOrEmpty(Name))
            {
                errorList.Add(new Error { Code = "CDNameRequired", Message = "CD name is required." });
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
        public int Number { get; set; }
        public string Title { get; set; }
        public int CD_ID { get; set; }
        public TimeSpan Length { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (string.IsNullOrEmpty(Title))
            {
                errorList.Add(new Error { Code = "TrackTitleRequired", Message = "Track title is required." });
            }

            if (Length.TotalSeconds <= 0)
            {
                errorList.Add(new Error { Code = "TrackLengthInvalid", Message = "Track length must be greater than zero." });
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
