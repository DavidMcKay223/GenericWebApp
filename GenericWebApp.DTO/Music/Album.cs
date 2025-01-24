using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Music
{
    public class Album : IEquatable<Album>
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }
        public List<CD> CDList { get; set; }

        public bool Equals(Album? other)
        {
            if (other == null) return false;

            return (String.Equals(ArtistName, other.ArtistName, StringComparison.OrdinalIgnoreCase));
        }
    }

    public class CD
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? Album_ID { get; set; }
        public int? Genre_ID { get; set; }
        public int? Label_ID { get; set; }

        public Label LabelObj { get; set; }
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

    public class Label_Genre
    {
        public int ID { get; set; }
        public int Genre_ID { get; set; }
        public int Label_ID { get; set; }

        public Genre Genre { get; set; }
        public Label Label { get; set; }
    }

    public class Label
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; }
        public DateTime? Founded { get; set; }
        public string Founder { get; set; }
        public DateTime? Defunct { get; set; }
        public List<Genre> GenreList { get; set; }
    }
}
