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
    public class AlbumContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public DbSet<CD> CDs { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Label_Genre> LabelGenres { get; set; }

        public AlbumContext(DbContextOptions<AlbumContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection", options =>
                options.EnableRetryOnFailure(
                    maxRetryCount: 5,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>()
                .HasMany(a => a.CDList)
                .WithOne(cd => cd.Album)
                .HasForeignKey(cd => cd.Album_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CD>()
                .HasMany(cd => cd.TrackList)
                .WithOne(track => track.CD)
                .HasForeignKey(track => track.CD_ID)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DTO.Common.Error SaveAlbum(Model.Music.Album album)
        {
            try
            {
                var existingAlbum = this.Albums
                    .Include(a => a.CDList)
                    .FirstOrDefault(a => a.ArtistName.Equals(album.ArtistName, StringComparison.OrdinalIgnoreCase));

                if (existingAlbum != null)
                {
                    existingAlbum.ArtistName = album.ArtistName;
                    existingAlbum.CDList = album.CDList;
                    this.Albums.Update(existingAlbum);
                }
                else
                {
                    this.Albums.Add(album);
                }

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

        public DTO.Common.Error SaveCD(Model.Music.CD cd)
        {
            try
            {
                var existingCD = this.CDs
                    .FirstOrDefault(c => c.Name.Equals(cd.Name, StringComparison.OrdinalIgnoreCase) && c.Album_ID == cd.Album_ID);

                if (existingCD != null)
                {
                    existingCD.Name = cd.Name;
                    existingCD.Genre_ID = cd.Genre_ID;
                    existingCD.Label_ID = cd.Label_ID;
                    existingCD.LabelObj = cd.LabelObj;
                    existingCD.TrackList = cd.TrackList;
                    this.CDs.Update(existingCD);
                }
                else
                {
                    this.CDs.Add(cd);
                }

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

        public DTO.Common.Error SaveTrack(Model.Music.Track track)
        {
            try
            {
                var existingTrack = this.Tracks
                    .FirstOrDefault(t => t.Title.Equals(track.Title, StringComparison.OrdinalIgnoreCase) && t.CD_ID == track.CD_ID);

                if (existingTrack != null)
                {
                    existingTrack.Number = track.Number;
                    existingTrack.Title = track.Title;
                    existingTrack.Length = track.Length;
                    this.Tracks.Update(existingTrack);
                }
                else
                {
                    this.Tracks.Add(track);
                }

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

        public DTO.Common.Error SaveGenre(Model.Music.Genre genre)
        {
            try
            {
                var existingGenre = this.Genres
                    .FirstOrDefault(g => g.Description.Equals(genre.Description, StringComparison.OrdinalIgnoreCase));

                if (existingGenre != null)
                {
                    existingGenre.Description = genre.Description;
                    this.Genres.Update(existingGenre);
                }
                else
                {
                    this.Genres.Add(genre);
                }

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

        public DTO.Common.Error SaveLabel(Model.Music.Label label)
        {
            try
            {
                var existingLabel = this.Labels
                    .FirstOrDefault(l => l.Name.Equals(label.Name, StringComparison.OrdinalIgnoreCase));

                if (existingLabel != null)
                {
                    existingLabel.Name = label.Name;
                    existingLabel.Founded = label.Founded;
                    existingLabel.Founder = label.Founder;
                    existingLabel.Defunct = label.Defunct;
                    existingLabel.GenreList = label.GenreList;
                    this.Labels.Update(existingLabel);
                }
                else
                {
                    this.Labels.Add(label);
                }

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

        public DTO.Common.Error SaveLabelGenre(Model.Music.Label_Genre labelGenre)
        {
            try
            {
                var existingLabelGenre = this.LabelGenres
                    .FirstOrDefault(lg => lg.Genre_ID == labelGenre.Genre_ID && lg.Label_ID == labelGenre.Label_ID);

                if (existingLabelGenre != null)
                {
                    existingLabelGenre.Genre = labelGenre.Genre;
                    existingLabelGenre.Label = labelGenre.Label;
                    this.LabelGenres.Update(existingLabelGenre);
                }
                else
                {
                    this.LabelGenres.Add(labelGenre);
                }

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

    [Table("Music_Album")]
    public class Album
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string ArtistName { get; set; }

        public List<CD> CDList { get; set; }

        public static DTO.Music.Album ParseDTO(Model.Music.Album album)
        {
            if (album == null) return null;

            DTO.Music.Album dto = new DTO.Music.Album
            {
                ID = album.ID,
                ArtistName = album.ArtistName,
                CDList = album.CDList?.Select(cd => CD.ParseDTO(cd)).ToList()
            };

            return dto;
        }

        public static Model.Music.Album ParseModel(DTO.Music.Album dto)
        {
            if (dto == null) return null;

            Model.Music.Album album = new Model.Music.Album
            {
                ID = dto.ID,
                ArtistName = dto.ArtistName,
                CDList = dto.CDList?.Select(cd => CD.ParseModel(cd)).ToList()
            };

            return album;
        }
    }

    [Table("Music_CD")]
    public class CD
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }

        public int? Album_ID { get; set; }

        public int? Genre_ID { get; set; }

        public int? Label_ID { get; set; }

        [ForeignKey("Label_ID")]
        public Label LabelObj { get; set; }

        public List<Track> TrackList { get; set; }
        public Album Album { get; internal set; }

        public static DTO.Music.CD ParseDTO(Model.Music.CD cd)
        {
            if (cd == null) return null;

            DTO.Music.CD dto = new DTO.Music.CD
            {
                ID = cd.ID,
                Name = cd.Name,
                Album_ID = cd.Album_ID,
                Genre_ID = cd.Genre_ID,
                Label_ID = cd.Label_ID,
                LabelObj = Label.ParseDTO(cd.LabelObj),
                TrackList = cd.TrackList?.Select(track => Track.ParseDTO(track)).ToList()
            };

            return dto;
        }

        public static Model.Music.CD ParseModel(DTO.Music.CD dto)
        {
            if (dto == null) return null;

            Model.Music.CD cd = new Model.Music.CD
            {
                ID = dto.ID,
                Name = dto.Name,
                Album_ID = dto.Album_ID,
                Genre_ID = dto.Genre_ID,
                Label_ID = dto.Label_ID,
                LabelObj = Label.ParseModel(dto.LabelObj),
                TrackList = dto.TrackList?.Select(track => Track.ParseModel(track)).ToList()
            };

            return cd;
        }
    }

    [Table("Music_Track")]
    public class Track
    {
        [Key]
        public int ID { get; set; }

        public int Number { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public int CD_ID { get; set; }

        public TimeSpan Length { get; set; }
        public CD CD { get; internal set; }

        public static DTO.Music.Track ParseDTO(Model.Music.Track track)
        {
            if (track == null) return null;

            DTO.Music.Track dto = new DTO.Music.Track
            {
                ID = track.ID,
                Number = track.Number,
                Title = track.Title,
                CD_ID = track.CD_ID,
                Length = track.Length
            };

            return dto;
        }

        public static Model.Music.Track ParseModel(DTO.Music.Track dto)
        {
            if (dto == null) return null;

            Model.Music.Track track = new Model.Music.Track
            {
                ID = dto.ID,
                Number = dto.Number,
                Title = dto.Title,
                CD_ID = dto.CD_ID,
                Length = dto.Length
            };

            return track;
        }
    }

    [Table("Music_Genre")]
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }

        public static DTO.Music.Genre ParseDTO(Model.Music.Genre genre)
        {
            if (genre == null) return null;

            DTO.Music.Genre dto = new DTO.Music.Genre
            {
                ID = genre.ID,
                Description = genre.Description
            };

            return dto;
        }

        public static Model.Music.Genre ParseModel(DTO.Music.Genre dto)
        {
            if (dto == null) return null;

            Model.Music.Genre genre = new Model.Music.Genre
            {
                ID = dto.ID,
                Description = dto.Description
            };

            return genre;
        }
    }

    [Table("Music_Label_Genre")]
    public class Label_Genre
    {
        [Key]
        public int ID { get; set; }
        public int Genre_ID { get; set; }
        public int Label_ID { get; set; }

        [ForeignKey("Genre_ID")]
        public Genre Genre { get; set; }

        [ForeignKey("Label_ID")]
        public Label Label { get; set; }

        public static DTO.Music.Label_Genre ParseDTO(Model.Music.Label_Genre labelGenre)
        {
            if (labelGenre == null) return null;

            DTO.Music.Label_Genre dto = new DTO.Music.Label_Genre
            {
                ID = labelGenre.ID,
                Genre_ID = labelGenre.Genre_ID,
                Label_ID = labelGenre.Label_ID,
                Genre = Genre.ParseDTO(labelGenre.Genre),
                Label = Label.ParseDTO(labelGenre.Label)
            };

            return dto;
        }

        public static Model.Music.Label_Genre ParseModel(DTO.Music.Label_Genre dto)
        {
            if (dto == null) return null;

            Model.Music.Label_Genre labelGenre = new Model.Music.Label_Genre
            {
                ID = dto.ID,
                Genre_ID = dto.Genre_ID,
                Label_ID = dto.Label_ID,
                Genre = Genre.ParseModel(dto.Genre),
                Label = Label.ParseModel(dto.Label)
            };

            return labelGenre;
        }
    }

    [Table("Music_Label")]
    public class Label
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Name { get; set; }

        public DateTime? Founded { get; set; }

        [MaxLength(500)]
        public string Founder { get; set; }

        public DateTime? Defunct { get; set; }

        public List<Genre> GenreList { get; set; }

        public static DTO.Music.Label ParseDTO(Model.Music.Label label)
        {
            if (label == null) return null;

            DTO.Music.Label dto = new DTO.Music.Label
            {
                ID = label.ID,
                Name = label.Name,
                Founded = label.Founded,
                Founder = label.Founder,
                Defunct = label.Defunct,
                GenreList = label.GenreList?.Select(genre => Genre.ParseDTO(genre)).ToList()
            };

            return dto;
        }

        public static Model.Music.Label ParseModel(DTO.Music.Label dto)
        {
            if (dto == null) return null;

            Model.Music.Label label = new Model.Music.Label
            {
                ID = dto.ID,
                Name = dto.Name,
                Founded = dto.Founded,
                Founder = dto.Founder,
                Defunct = dto.Defunct,
                GenreList = dto.GenreList?.Select(genre => Genre.ParseModel(genre)).ToList()
            };

            return label;
        }
    }
}
