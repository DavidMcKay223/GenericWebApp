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
            base.OnModelCreating(modelBuilder);

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

            modelBuilder.Entity<Album>()
                .HasIndex(a => a.ArtistName);

            modelBuilder.Entity<CD>()
                .HasIndex(cd => cd.Name);

            modelBuilder.Entity<Track>()
                .HasIndex(t => t.Title);
        }
    }
}
