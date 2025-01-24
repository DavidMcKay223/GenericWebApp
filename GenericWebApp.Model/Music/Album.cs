using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Music
{
    public class AlbumContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }

        public DTO.Common.Error SaveAlbum(Model.Music.Album album)
        {
            try
            {
                this.Albums.Add(album);
                this.SaveChanges();
                return null;
            }
            catch (Exception ex)
            {
                return new DTO.Common.Error
                {
                    Message = ex.Message
                };
            }
        }
    }

    public class Album
    {
        public int ID { get; set; }
        public string ArtistName { get; set; }

        public static DTO.Music.Album ParseDTO(Model.Music.Album album)
        {
            if(album == null) return null;

            DTO.Music.Album dto = 
                new DTO.Music.Album()
                {
                    ID = album.ID,
                    ArtistName = album.ArtistName,
                    //CDList = 
                };

            return dto;
        }
    }
}
