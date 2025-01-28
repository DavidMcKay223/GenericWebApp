using GenericWebApp.Model.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Management
{
    public class DashboardAlbumService
    {
        private readonly AlbumContext? _context;

        public DashboardAlbumService()
        {
        }

        public DashboardAlbumService(AlbumContext context)
        {
            _context = context;
        }

        public List<GenericWebApp.DTO.Management.Dashboard_MusicSummary> GetDashboardMusicSummary()
        {
            if(_context == null)
            {
                throw new ArgumentNullException(nameof(_context));
            }

            var dashboardQuery = from g in _context.Genres
                                 join c in _context.CDs on g.ID equals c.Genre_ID into genreCDs
                                 from gc in genreCDs.DefaultIfEmpty()
                                 join a in _context.Albums on gc.Album_ID equals a.ID into cdAlbums
                                 from ca in cdAlbums.DefaultIfEmpty()
                                 join t in _context.Tracks on gc.ID equals t.CD_ID into cdTracks
                                 from ct in cdTracks.DefaultIfEmpty()
                                 select new { g.Description, Album = ca, CD = gc, Track = ct };

            var groupedResult = dashboardQuery
                                .AsEnumerable()
                                .GroupBy(x => x.Description)
                                .Select(group => new GenericWebApp.DTO.Management.Dashboard_MusicSummary
                                {
                                    GenreName = group.Key,
                                    AlbumCount = group.Select(x => x.Album).Distinct().Count(a => a != null),
                                    CDCount = group.Select(x => x.CD).Distinct().Count(cd => cd != null),
                                    TotalTrackCount = group.Count(x => x.Track != null),
                                    TotalTrackLength = TimeSpan.FromTicks(group.Sum(x => x.Track != null ? x.Track.Length.Ticks : 0))
                                })
                                .ToList();

            return groupedResult;
        }
    }
}
