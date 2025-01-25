using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using GenericWebApp.BLL.Common;
using GenericWebApp.DTO.Common;
using GenericWebApp.DTO.Music;
using GenericWebApp.Model.Music;
using Microsoft.EntityFrameworkCore;
using GenericWebApp.UnitTest.Common;
using System.Linq;

namespace GenericWebApp.UnitTest.Music
{
    public class ServiceTest : IClassFixture<Common.AlbumDatabaseFixture>
    {
        private readonly AlbumContext _context;
        private readonly BLL.Music.Service _service;
        private readonly Common.AlbumDatabaseFixture _fixture;

        public ServiceTest(Common.AlbumDatabaseFixture fixture)
        {
            _context = fixture.Context;
            _service = new BLL.Music.Service(_context);
            _fixture = fixture;
        }

        public void Initialize()
        {
            _fixture.SeedData();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesAlbumCorrectly()
        {
            Initialize();
            var assertCollection = new AssertCollection("Deleting album correctly");

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "The Beatles" };

            // Act
            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("Album should be deleted", () => Assert.Equal(3, _service.Response.List.Count));
            assertCollection.Assert("Album should not be in the list", () => Assert.DoesNotContain(_service.Response.List, a => a.ArtistName == "The Beatles"));
            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesAlbumIncorrectly()
        {
            Initialize();
            var assertCollection = new AssertCollection("Attempt to delete a non-existent album");

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "Nonexistent Artist" };

            // Act
            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("No album should be deleted", () => Assert.Equal(4, _service.Response.List.Count));
            assertCollection.Assert("Error message should indicate deletion failure", () => Assert.Contains(_service.Response.ErrorList, e => e.Message == "Item did not delete"));
            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesAlbumWithCD()
        {
            Initialize();
            var assertCollection = new AssertCollection("Deleting album with CDs");

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "The Beatles" };

            // Act
            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("Album with CDs should be deleted", () => Assert.Equal(3, _service.Response.List.Count));
            assertCollection.Assert("Album should not be in the list", () => Assert.DoesNotContain(_service.Response.List, a => a.ArtistName == "The Beatles"));
            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesAlbumWithCDWithTrack()
        {
            Initialize();
            var assertCollection = new AssertCollection("Deleting album with CDs and tracks");

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "Daft Punk" };

            // Act
            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("Album with CDs and tracks should be deleted", () => Assert.Equal(3, _service.Response.List.Count));
            assertCollection.Assert("Album should not be in the list", () => Assert.DoesNotContain(_service.Response.List, a => a.ArtistName == "Daft Punk"));
            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesCD()
        {
            Initialize();
            var assertCollection = new AssertCollection("Deleting CD from album");

            // Arrange
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            var album = _service.Response.List.Find(a => a.ArtistName == "The Beatles");
            var cdToDelete = album?.CDList.Find(cd => cd.Name == "Abbey Road");
            assertCollection.Assert("The CD to delete should exist", () => Assert.NotNull(cdToDelete));

            // Act
            if (cdToDelete != null)
            {
                album.CDList.Remove(cdToDelete);

                // Convert album DTO to model before saving
                await _service.SaveItemAsync(album);

                // Check for errors and display code and description for each message
                var errorMessages = string.Join(", ", _service.Response.ErrorList.Select(e => $"\n\t\tCode: {e.Code}, \n\t\tDescription: {e.Message}"));
                assertCollection.Assert("No errors should be present",
                    () => Assert.False(_service.Response.ErrorList.Any(),
                    $"Errors: {errorMessages}"));

                // Re-fetch the album object to ensure it's updated
                await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
                var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "The Beatles");

                // Assert
                assertCollection.Assert("Album should still exist", () => Assert.NotNull(savedAlbum));
                assertCollection.Assert("CD should be removed from album", () => Assert.DoesNotContain(savedAlbum.CDList, cd => cd.Name == "Abbey Road"));
            }

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesTracks()
        {
            Initialize();
            var assertCollection = new AssertCollection("Deleting track from CD");

            // Arrange
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            var album = _service.Response.List.Find(a => a.ArtistName == "The Beatles");
            var cd = album.CDList.Find(cd => cd.Name == "Abbey Road");
            var trackToDelete = cd.TrackList.Find(track => track.Title == "Come Together");

            // Act
            cd.TrackList.Remove(trackToDelete);
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "The Beatles");
            assertCollection.Assert("Album should still exist", () => Assert.NotNull(savedAlbum));
            var savedCD = savedAlbum.CDList.Find(cd => cd.Name == "Abbey Road");
            assertCollection.Assert("CD should still exist", () => Assert.NotNull(savedCD));
            assertCollection.Assert("Track should be removed from CD", () => Assert.DoesNotContain(savedCD.TrackList, t => t.Title == "Come Together"));
            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_ReturnsCorrectAlbum()
        {
            Initialize();
            var assertCollection = new AssertCollection("Retrieving correct album");

            // Arrange
            var searchParams = new BLL.Music.MusicSearchDTO() { ArtistName = "Eminem" };

            // Act
            await _service.GetItemAsync(searchParams);

            // Assert
            assertCollection.Assert("Album should be retrieved", () => Assert.NotNull(_service.Response.Item));
            assertCollection.Assert("Album artist name should be 'Eminem'", () => Assert.Equal("Eminem", _service.Response.Item.ArtistName));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsAllAlbums()
        {
            Initialize();
            var assertCollection = new AssertCollection("Retrieving all albums");

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("All albums should be retrieved", () => Assert.Equal(4, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithArtist()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album with artist");

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "New Artist", CDList = new List<DTO.Music.CD>() };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("New album should be added", () => Assert.Equal(5, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            assertCollection.Assert("New artist should be in the list", () => Assert.Contains(_service.Response.List, a => a.ArtistName == "New Artist"));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithCDGenreID()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album with CD having Genre_ID");

            // Retrieve the genre IDs from the database
            var genreDictionary = _context.Genres.ToDictionary(g => g.Description, g => g.ID);

            // Arrange
            var album = new DTO.Music.Album
            {
                ArtistName = "Artist with CD genre",
                CDList = new List<DTO.Music.CD>
                {
                    new DTO.Music.CD
                    {
                        Name = "CD with Genre",
                        Genre_ID = genreDictionary["Rock"], // Using the dictionary to set Genre_ID
                        TrackList = new List<DTO.Music.Track>
                        {
                            new DTO.Music.Track { Number = 1, Title = "Track 1", Length = TimeSpan.FromMinutes(3.00) }
                        }
                    }
                }
            };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("New album should be added", () => Assert.Equal(5, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "Artist with CD genre");
            assertCollection.Assert("New album should be found", () => Assert.NotNull(savedAlbum));
            assertCollection.Assert("New album should have one CD", () => Assert.Single(savedAlbum.CDList));
            assertCollection.Assert("CD should have correct Genre_ID", () => Assert.Equal(genreDictionary["Rock"], savedAlbum.CDList[0].Genre_ID));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithCDNoTitle()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album with CD having no title");

            // Arrange
            var album = new DTO.Music.Album
            {
                ArtistName = "Artist with CD no title",
                CDList = new List<DTO.Music.CD> { new DTO.Music.CD { Name = "" } }
            };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("Album should not be added due to missing CD title", () => Assert.Equal(4, _service.Response.List.Count));
            assertCollection.Assert("Error list should contain CDNameRequired error", () => Assert.Contains(_service.Response.ErrorList, e => e.Code == "CDNameRequired" && e.Message == "CD name is required."));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithCDTitle()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album with CD having title");

            // Arrange
            var album = new DTO.Music.Album
            {
                ArtistName = "Artist with CD title",
                CDList = new List<DTO.Music.CD> { new DTO.Music.CD { Name = "CD Title" } }
            };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("New album should be added", () => Assert.Equal(5, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "Artist with CD title");
            assertCollection.Assert("New album should be found", () => Assert.NotNull(savedAlbum));
            assertCollection.Assert("New album should have one CD", () => Assert.Single(savedAlbum.CDList));
            assertCollection.Assert("CD should have correct title", () => Assert.Equal("CD Title", savedAlbum.CDList[0].Name));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithCDTrackNoDescription()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album with CD track having no description");

            // Arrange
            var album = new DTO.Music.Album
            {
                ArtistName = "Artist with CD Track no description",
                CDList = new List<DTO.Music.CD>
                {
                    new DTO.Music.CD
                    {
                        Name = "CD",
                        TrackList = new List<DTO.Music.Track> { new DTO.Music.Track { Number = 1, Title = "", Length = TimeSpan.FromMinutes(3.00) } }
                    }
                }
            };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("Album should not be added due to missing track title", () => Assert.Equal(4, _service.Response.List.Count));
            assertCollection.Assert("Error list should contain TrackTitleRequired error", () => Assert.Contains(_service.Response.ErrorList, e => e.Code == "TrackTitleRequired" && e.Message == "Track title is required."));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithMultipleCDsAndGenreIDs()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album with multiple CDs and Genre_IDs");

            // Retrieve the genre IDs from the database
            var genreDictionary = _context.Genres.ToDictionary(g => g.Description, g => g.ID);

            // Arrange
            var album = new DTO.Music.Album
            {
                ArtistName = "Artist with multiple CDs and genres",
                CDList = new List<DTO.Music.CD>
                {
                    new DTO.Music.CD
                    {
                        Name = "CD1 with Genre",
                        Genre_ID = genreDictionary["Rock"], // Using the dictionary to set Genre_ID
                        TrackList = new List<DTO.Music.Track>
                        {
                            new DTO.Music.Track { Number = 1, Title = "Track 1", Length = TimeSpan.FromMinutes(3.00) }
                        }
                    },
                    new DTO.Music.CD
                    {
                        Name = "CD2 with Genre",
                        Genre_ID = genreDictionary["Pop"], // Using the dictionary to set Genre_ID
                        TrackList = new List<DTO.Music.Track>
                        {
                            new DTO.Music.Track { Number = 1, Title = "Track 2", Length = TimeSpan.FromMinutes(4.00) }
                        }
                    }
                }
            };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("New album should be added", () => Assert.Equal(5, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "Artist with multiple CDs and genres");
            assertCollection.Assert("New album should be found", () => Assert.NotNull(savedAlbum));
            assertCollection.Assert("New album should have two CDs", () => Assert.Equal(2, savedAlbum.CDList.Count));
            assertCollection.Assert("First CD should have correct Genre_ID", () => Assert.Equal(genreDictionary["Rock"], savedAlbum.CDList[0].Genre_ID));
            assertCollection.Assert("Second CD should have correct Genre_ID", () => Assert.Equal(genreDictionary["Pop"], savedAlbum.CDList[1].Genre_ID));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_AlbumWithoutArtist()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album without artist");

            // Arrange
            var album = new DTO.Music.Album { CDList = new List<DTO.Music.CD>() };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("Album should not be added due to missing artist name", () => Assert.Equal(4, _service.Response.List.Count));
            assertCollection.Assert("Error list should contain ArtistNameRequired error", () => Assert.Contains(_service.Response.ErrorList, e => e.Code == "ArtistNameRequired" && e.Message == "Artist name is required."));
            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_SavesAlbumCorrectly()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving album correctly");

            // Arrange
            var album = new DTO.Music.Album
            {
                ArtistName = "New Artist",
                CDList = new List<DTO.Music.CD>
                {
                    new DTO.Music.CD
                    {
                        Name = "New Album",
                        TrackList = new List<DTO.Music.Track>
                        {
                            new DTO.Music.Track { Number = 1, Title = "Track 1", Length = TimeSpan.FromMinutes(3.00) }
                        }
                    }
                }
            };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            assertCollection.Assert("New album should be added", () => Assert.Equal(5, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "New Artist");
            assertCollection.Assert("New album should be found", () => Assert.NotNull(savedAlbum));
            assertCollection.Assert("New album should have one CD", () => Assert.Single(savedAlbum.CDList));
            assertCollection.Assert("CD should have correct title", () => Assert.Equal("New Album", savedAlbum.CDList[0].Name));
            assertCollection.Assert("CD should have one track", () => Assert.Single(savedAlbum.CDList[0].TrackList));
            assertCollection.Assert("Track should have correct title", () => Assert.Equal("Track 1", savedAlbum.CDList[0].TrackList[0].Title));
            assertCollection.Verify();
        }
    }
}
