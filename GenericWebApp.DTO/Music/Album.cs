using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Music
{
    public class Album
    {
        public string ArtistName { get; set; }
        public List<CD> CDList { get; set; }
    }

    public class CD
    {
        public string Name { get; set; }
        public string Genere { get; set; }
        public List<Track> TrackList { get; set; }
    }

    public class Track
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public decimal Length { get; set; }
    }
}
