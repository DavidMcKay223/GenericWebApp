using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Music
{
    public class Album
    {
        public int? ID { get; set; }
        public string ArtistName { get; set; }
        public List<CD> CDList { get; set; }
    }

    public class CD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Album_ID { get; set; }
        public int? Genre_ID { get; set; }

        public List<Track> TrackList { get; set; }
    }

    public class Track
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Title { get; set; }
        public int CD_ID { get; set; }
        public TimeSpan Length { get; set; }
    }

    public class Genre
    {
        public int ID { get; set; }
        public string Description { get; set; }
    }
}
