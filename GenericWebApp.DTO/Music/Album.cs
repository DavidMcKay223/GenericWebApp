using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Music
{
    public class Album : IEquatable<Album>
    {
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
        public string Name { get; set; }
        public string Genere { get; set; }
        public string Label { get; set; }
        public List<Track> TrackList { get; set; }
    }

    public class Track
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public TimeOnly Length { get; set; }
    }
}
