using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Management
{
    public class Dashboard_MusicSummary
    {
        public string? GenreName { get; set; }
        public int AlbumCount { get; set; }
        public int CDCount { get; set; }
        public int TotalTrackCount { get; set; }
        public TimeSpan TotalTrackLength { get; set; }
    }
}