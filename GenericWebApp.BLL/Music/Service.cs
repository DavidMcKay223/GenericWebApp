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
    public class Service : GenericWebApp.BLL.Common.ServiceManager<GenericWebApp.DTO.Music.Album, GenericWebApp.BLL.Music.MusicSearchDTO>
    {
        private readonly AlbumContext _context;

        public Service(AlbumContext context)
        {
            _context = context;
        }

        public override async Task DeleteItemAsync(GenericWebApp.DTO.Music.Album dto)
        {
            Response.Error = null;

            try
            {
                // Find the album by artist name and include related CDs and Tracks
                var album = await _context.Albums
                    .Include(a => a.CDList)
                        .ThenInclude(cd => cd.TrackList)
                    .FirstOrDefaultAsync(a => a.ArtistName.ToLower() == dto.ArtistName.ToLower());

                if (album != null)
                {
                    // Remove the album, CDs, and Tracks
                    _context.Albums.Remove(album);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Response.Error = new GenericWebApp.DTO.Common.Error { Message = "Item did not delete" };
                }
            }
            catch (Exception ex)
            {
                Response.Error = new GenericWebApp.DTO.Common.Error { Message = ex.Message };
            }
        }


        public override async Task SaveItemAsync(GenericWebApp.DTO.Music.Album dto, bool isNew = false)
        {
            Response.Error = null;

            try
            {
                var album = GenericWebApp.Model.Music.Album.ParseModel(dto);

                if (isNew)
                {
                    var existingAlbum = await _context.Albums.FirstOrDefaultAsync(a => a.ArtistName.ToLower() == dto.ArtistName.ToLower());
                    if (existingAlbum == null)
                    {
                        await _context.Albums.AddAsync(album);
                    }
                    else
                    {
                        Response.Error = new GenericWebApp.DTO.Common.Error { Message = "Artist Exists Already" };
                        return;
                    }
                }
                else
                {
                    var existingAlbum = await _context.Albums.Include(a => a.CDList).FirstOrDefaultAsync(a => a.ArtistName.ToLower() == dto.ArtistName.ToLower());
                    if (existingAlbum != null)
                    {
                        existingAlbum.ArtistName = album.ArtistName;
                        existingAlbum.CDList = album.CDList;
                        _context.Albums.Update(existingAlbum);
                    }
                    else
                    {
                        await _context.Albums.AddAsync(album);
                    }
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Response.Error = new GenericWebApp.DTO.Common.Error { Message = ex.Message };
            }
        }

        public override async Task<GenericWebApp.DTO.Music.Album> GetItemAsync(GenericWebApp.BLL.Music.MusicSearchDTO searchParams)
        {
            try
            {
                var album = await _context.Albums.Include(a => a.CDList).ThenInclude(cd => cd.TrackList)
                    .FirstOrDefaultAsync(a => a.ArtistName.ToLower() == searchParams.ArtistName.ToLower());

                return GenericWebApp.Model.Music.Album.ParseDTO(album);
            }
            catch (Exception ex)
            {
                Response.Error = new GenericWebApp.DTO.Common.Error { Message = ex.Message };
                return null;
            }
        }

        public override async Task<List<GenericWebApp.DTO.Music.Album>> GetListAsync(MusicSearchDTO searchParams)
        {
            try
            {
                if (searchParams == null)
                {
                    Response.Error = new GenericWebApp.DTO.Common.Error { Message = "Search parameters are null" };
                    return new List<GenericWebApp.DTO.Music.Album>();
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

                var albums = await query.ToListAsync();

                // Filter down CDs and tracks if necessary
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

                return albums.Select(GenericWebApp.Model.Music.Album.ParseDTO).ToList();
            }
            catch (Exception ex)
            {
                Response.Error = new GenericWebApp.DTO.Common.Error { Message = ex.Message };
                return new List<GenericWebApp.DTO.Music.Album>();
            }
        }
    }

    public class MusicSearchDTO
    {
        public string ArtistName { get; set; }
        public string CdName { get; set; }
        public string TrackTitle { get; set; }
    }
}
