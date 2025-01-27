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
        public required string ArtistName { get; set; }

        public List<CD>? CDList { get; set; }
    }

    [Table("Music_CD")]
    public class CD
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public required string Name { get; set; }

        public int? Album_ID { get; set; }

        public int? Genre_ID { get; set; }

        public List<Track>? TrackList { get; set; }
        public Album? Album { get; set; }
    }

    [Table("Music_Track")]
    public class Track
    {
        [Key]
        public int ID { get; set; }

        public int Number { get; set; }

        [MaxLength(500)]
        public required string Title { get; set; }

        public int CD_ID { get; set; }

        public TimeSpan Length { get; set; }
        public CD? CD { get; set; }
    }

    [Table("Music_Genre")]
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public required string Description { get; set; }
    }
}
