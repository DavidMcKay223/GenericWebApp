using GenericWebApp.DTO.Music;
using GenericWebApp.BLL.Common;
using GenericWebApp.Model.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.BLL.Music
{
    public class Service : ServiceManager<GenericWebApp.DTO.Music.Album, GenericWebApp.BLL.Music.MusicSearchDTO>
    {
        private readonly AlbumContext _context;

        public Service(AlbumContext context)
        {
            _context = context;
        }

        public List<DTO.Common.ValuePair> GetGenreList()
        {
            List<DTO.Common.ValuePair> myList = new List<DTO.Common.ValuePair>();

            var genres = _context.Genres.ToList();

            foreach (var genre in genres)
            {
                myList.Add(new DTO.Common.ValuePair { Description = genre.Description, ID = genre.ID });
            }

            return myList;
        }

        public override async Task DeleteItemAsync(GenericWebApp.DTO.Music.Album dto)
        {
            Response.ErrorList.Clear();

            try
            {
                var album = await _context.Albums
                    .Include(a => a.CDList)
                        .ThenInclude(cd => cd.TrackList)
                    .FirstOrDefaultAsync(a => a.ArtistName.ToLower() == dto.ArtistName.ToLower());

                if (album != null)
                {
                    _context.Albums.Remove(album);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = "Item did not delete" });
                }
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = ex.Message });
            }
        }

        public override async Task SaveItemAsync(GenericWebApp.DTO.Music.Album dto)
        {
            Response.ErrorList.Clear();

            if (dto.IsValid(Response.ErrorList))
            {
                try
                {
                    var album = GenericWebApp.Model.Music.Album.ParseModel(dto);

                    if (dto.ID == null)
                    {
                        var existingAlbum = await _context.Albums.Include(a => a.CDList).FirstOrDefaultAsync(a => a.ArtistName.ToLower() == dto.ArtistName.ToLower());
                        if (existingAlbum != null)
                        {
                            Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = "An album with the same artist name already exists." });
                            return;
                        }

                        await _context.Albums.AddAsync(album);
                    }
                    else
                    {
                        var existingAlbum = await _context.Albums.Include(a => a.CDList).FirstOrDefaultAsync(a => a.ID == dto.ID);
                        if (existingAlbum != null)
                        {
                            existingAlbum.ArtistName = album.ArtistName;
                            existingAlbum.CDList = album.CDList;
                            _context.Albums.Update(existingAlbum);
                        }
                        else
                        {
                            Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = "Album not found." });
                            return;
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = ex.Message });
                }
            }
        }

        public override async Task GetItemAsync(GenericWebApp.BLL.Music.MusicSearchDTO searchParams)
        {
            Response.ErrorList.Clear();

            try
            {
                var album = await _context.Albums
                    .Include(a => a.CDList)
                        .ThenInclude(cd => cd.TrackList)
                    .FirstOrDefaultAsync(a => a.ArtistName.ToLower() == searchParams.ArtistName.ToLower());

                Response.Item = GenericWebApp.Model.Music.Album.ParseDTO(album);
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = ex.Message });
                Response.Item = null;
            }
        }

        public override async Task GetListAsync(GenericWebApp.BLL.Music.MusicSearchDTO searchParams)
        {
            try
            {
                if (searchParams == null)
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = "Search parameters are null" });
                    Response.List = new List<GenericWebApp.DTO.Music.Album>();
                    return;
                }

                var query = _context.Albums
                    .Include(a => a.CDList)
                        .ThenInclude(cd => cd.TrackList)
                    .AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchParams.ArtistName))
                {
                    query = query.Where(a => a.ArtistName.ToLower().Contains(searchParams.ArtistName.ToLower()));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.CdName))
                {
                    query = query.Where(a => a.CDList.Any(cd => cd.Name.ToLower().Contains(searchParams.CdName.ToLower())));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.TrackTitle))
                {
                    query = query.Where(a => a.CDList.Any(cd => cd.TrackList.Any(t => t.Title.ToLower().Contains(searchParams.TrackTitle.ToLower()))));
                }

                if (searchParams.GenreID.HasValue)
                {
                    query = query.Where(a => a.CDList.Any(cd => cd.Genre_ID == searchParams.GenreID.Value));
                }

                var albums = await query.ToListAsync();

                if (!string.IsNullOrWhiteSpace(searchParams.CdName))
                {
                    foreach (var album in albums)
                    {
                        album.CDList = album.CDList
                            .Where(cd => cd.Name.ToLower().Contains(searchParams.CdName.ToLower()))
                            .ToList();
                    }
                    albums = albums.Where(album => album.CDList.Any()).ToList();
                }

                if (!string.IsNullOrWhiteSpace(searchParams.TrackTitle))
                {
                    foreach (var album in albums)
                    {
                        foreach (var cd in album.CDList)
                        {
                            cd.TrackList = cd.TrackList
                                .Where(t => t.Title.ToLower().Contains(searchParams.TrackTitle.ToLower()))
                                .ToList();
                        }
                        album.CDList = album.CDList.Where(cd => cd.TrackList.Any()).ToList();
                    }
                    albums = albums.Where(album => album.CDList.Any()).ToList();
                }

                if (searchParams.GenreID.HasValue)
                {
                    foreach (var album in albums)
                    {
                        album.CDList = album.CDList
                            .Where(cd => cd.Genre_ID == searchParams.GenreID.Value)
                            .ToList();
                    }
                    albums = albums.Where(album => album.CDList.Any()).ToList();
                }

                Response.List = albums.Select(GenericWebApp.Model.Music.Album.ParseDTO).ToList();
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Message = ex.Message });
                Response.List = new List<GenericWebApp.DTO.Music.Album>();
            }
        }
    }

    public class MusicSearchDTO
    {
        public string ArtistName { get; set; }
        public string CdName { get; set; }
        public string TrackTitle { get; set; }
        public int? GenreID { get; set; }
    }
}
