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
        private readonly AlbumContext? _context;

        public Service()
        {

        }

        public Service(AlbumContext context)
        {
            _context = context;
        }

        public async Task<List<DTO.Common.ValuePair>> GetGenreList()
        {
            if(_context == null)
            {
                Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                return [];
            }

            return await _context.Genres
                .Select(genre => new DTO.Common.ValuePair
                {
                    Description = genre.Description,
                    ID = genre.ID
                })
                .ToListAsync();
        }

        public override async Task DeleteItemAsync(GenericWebApp.DTO.Music.Album dto)
        {
            Response.ErrorList.Clear();

            try
            {
                if (_context == null)
                {
                    Response.ErrorList.Add(new DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                var album = await _context.Albums
                    .Include(a => a.CDList!)
                        .ThenInclude(cd => cd.TrackList!)
                    .FirstOrDefaultAsync(a => a.ArtistName.ToLower().Contains(dto.ArtistName.ToLower()));

                if (album != null)
                {
                    _context.Albums.Remove(album);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "ItemDeletionFailed", Message = "Item did not delete" });
                }
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = ex.Source, Message = ex.Message });
            }
        }

        public override async Task SaveItemAsync(GenericWebApp.DTO.Music.Album dto)
        {
            Response.ErrorList.Clear();

            if (dto.IsValid(Response.ErrorList))
            {
                try
                {
                    Model.Music.Album? album;

                    if (dto.ID == null || dto.ID == 0)
                    {
                        if(_context == null)
                        {
                            Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                            return;
                        }

                        var existingAlbum = await _context.Albums
                            .Include(a => a.CDList!)
                            .FirstOrDefaultAsync(a => a.ArtistName.ToLower().Contains(dto.ArtistName.ToLower()));

                        if (existingAlbum != null)
                        {
                            Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "DuplicateAlbum", Message = "An album with the same artist name already exists." });
                            return;
                        }

                        album = new Model.Music.Album() { ArtistName = String.Empty, CDList = [] };
                        GenericWebApp.Model.Common.AlbumModelParser.ParseModel(album, dto);
                        await _context.Albums.AddAsync(album);
                    }
                    else
                    {
                        if(_context == null)
                        {
                            Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                            return;
                        }

                        album = await _context.Albums
                            .Include(a => a.CDList)
                                .ThenInclude(cd => cd.TrackList)
                            .FirstOrDefaultAsync(a => a.ID == dto.ID);

                        if (album != null)
                        {
                            GenericWebApp.Model.Common.AlbumModelParser.ParseModel(album, dto);
                            _context.Albums.Update(album);
                        }
                        else
                        {
                            Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "AlbumNotFound", Message = "Album not found." });
                            return;
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = ex.Source, Message = ex.Message });
                }
            }
        }

        public override async Task GetItemAsync(GenericWebApp.BLL.Music.MusicSearchDTO searchParams)
        {
            Response.ErrorList.Clear();

            try
            {
                if (searchParams == null)
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "NullSearchParams", Message = "Search parameters are null" });
                    Response.Item = null;
                    return;
                }

                if (_context == null)
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                    Response.Item = null;
                    return;
                }

                var album = await _context.Albums
                    .Include(a => a.CDList!)
                        .ThenInclude(cd => cd.TrackList!)
                    .FirstOrDefaultAsync(a => a.ArtistName.ToLower().Contains(searchParams.ArtistName!.ToLower()));

                if (album != null)
                {
                    Response.Item = GenericWebApp.Model.Common.AlbumDTOParser.ParseDTO(album);
                }
                else
                {
                    Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = "AlbumNotFound", Message = "Album not found." });
                    Response.Item = null;
                }
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new GenericWebApp.DTO.Common.Error { Code = ex.Source, Message = ex.Message });
                Response.Item = null;
            }
        }

        public override async Task GetListAsync(MusicSearchDTO searchParams)
        {
            try
            {
                if (searchParams == null)
                {
                    Response.ErrorList.Add(new DTO.Common.Error { Code = "NullSearchParams", Message = "Search parameters are null" });
                    Response.List = [];
                    return;
                }

                if (_context == null)
                {
                    Response.ErrorList.Add(new DTO.Common.Error { Code = "ContextIsNull", Message = "Context is null" });
                    return;
                }

                // Start with a fresh query
                var query = _context.Albums
                    .Include(a => a.CDList)
                        .ThenInclude(cd => cd.TrackList)
                    .AsNoTracking()
                    .AsQueryable();

                // Apply filters dynamically
                if (!string.IsNullOrWhiteSpace(searchParams.ArtistName))
                {
                    var artistNameLower = searchParams.ArtistName.ToLower();
                    query = query.Where(a => a.ArtistName.ToLower().Contains(artistNameLower));
                }

                if (searchParams.GenreID.HasValue)
                {
                    query = query.Where(a => a.CDList.Any(cd => cd.Genre_ID == searchParams.GenreID.Value));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.CdName))
                {
                    var cdNameLower = searchParams.CdName.ToLower();
                    query = query.Where(a => a.CDList.Any(cd => cd.Name.ToLower().Contains(cdNameLower)));
                }

                if (!string.IsNullOrWhiteSpace(searchParams.TrackTitle))
                {
                    var trackTitleLower = searchParams.TrackTitle.ToLower();
                    query = query.Where(a => a.CDList.Any(cd => cd.TrackList.Any(t => t.Title.ToLower().Contains(trackTitleLower))));
                }

                // Apply sorting
                query = searchParams.SortField switch
                {
                    "ArtistName" => searchParams.SortDescending ? query.OrderByDescending(a => a.ArtistName) : query.OrderBy(a => a.ArtistName),
                    "CdName" => searchParams.SortDescending ? query.OrderByDescending(a => a.CDList.FirstOrDefault() != null ? a.CDList.FirstOrDefault()!.Name : string.Empty) : query.OrderBy(a => a.CDList.FirstOrDefault() != null ? a.CDList.FirstOrDefault()!.Name : string.Empty),
                    _ => query
                };

                // Get total count before applying pagination
                var totalItems = await query.CountAsync();

                // Apply pagination
                var albums = await query
                    .Skip(searchParams.PageNumber * searchParams.PageSize)
                    .Take(searchParams.PageSize)
                    .ToListAsync();

                // Further filter the CD and Track lists
                foreach (var album in albums)
                {
                    if (album.CDList != null)
                    {
                        if (!string.IsNullOrWhiteSpace(searchParams.CdName))
                        {
                            var cdNameLower = searchParams.CdName.ToLower();
                            album.CDList = album.CDList
                                .Where(cd => cd.Name.ToLower().Contains(cdNameLower))
                                .ToList();
                        }

                        if (!string.IsNullOrWhiteSpace(searchParams.TrackTitle))
                        {
                            var trackTitleLower = searchParams.TrackTitle.ToLower();
                            foreach (var cd in album.CDList)
                            {
                                if (cd.TrackList != null)
                                {
                                    cd.TrackList = cd.TrackList
                                        .Where(t => t.Title.ToLower().Contains(trackTitleLower))
                                        .ToList();
                                }
                            }
                            album.CDList = album.CDList.Where(cd => cd.TrackList.Count != 0).ToList();
                        }
                    }
                }

                Response.List = albums.ConvertAll(Model.Common.AlbumDTOParser.ParseDTO);
                Response.TotalItems = totalItems;
            }
            catch (Exception ex)
            {
                Response.ErrorList.Add(new DTO.Common.Error { Code = ex.Source, Message = ex.Message });
                Response.List = [];
            }
        }
    }

    public class MusicSearchDTO : SearchDTO
    {
        public string? ArtistName { get; set; }
        public string? CdName { get; set; }
        public string? TrackTitle { get; set; }
        public int? GenreID { get; set; }
    }
}
