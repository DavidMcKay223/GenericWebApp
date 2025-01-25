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
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            var initialAlbumCount = _service.Response.List.Count;

            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Retrieve the updated list of albums
            var updatedAlbums = _service.Response.List;

            // Assert
            assertCollection.Assert("Album should be deleted", () => Assert.Equal(initialAlbumCount - 1, updatedAlbums.Count));
            assertCollection.Assert("Album should not be in the list", () => Assert.DoesNotContain(updatedAlbums, a => a.ArtistName == "The Beatles"));

            // Additional assertions to ensure the album is deleted from the service
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "The Beatles" });
            updatedAlbums = _service.Response.List;
            assertCollection.Assert("Album should be deleted from the service", () => Assert.DoesNotContain(updatedAlbums, a => a.ArtistName == "The Beatles"));

            // Verify error list
            assertCollection.AssertErrorList("Error list should be empty", _service.Response.ErrorList);

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
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            var initialAlbumCount = _service.Response.List.Count;

            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Retrieve the updated list of albums
            var updatedAlbums = _service.Response.List;

            // Assert
            assertCollection.Assert("No album should be deleted", () => Assert.Equal(initialAlbumCount, updatedAlbums.Count));
            assertCollection.AssertErrorList("Error list should contain deletion failure error", _service.Response.ErrorList);

            // Additional assertions to ensure the album count remains the same in the service
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            updatedAlbums = _service.Response.List;
            assertCollection.Assert("Album count should remain the same", () => Assert.Equal(initialAlbumCount, updatedAlbums.Count));

            // Verify error list
            assertCollection.AssertErrorList("Error list should contain deletion failure error", _service.Response.ErrorList);

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
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            var initialAlbumCount = _service.Response.List.Count;

            await _service.DeleteItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Retrieve the updated list of albums
            var updatedAlbums = _service.Response.List;

            // Assert
            assertCollection.Assert("Album with CDs should be deleted", () => Assert.Equal(initialAlbumCount - 1, updatedAlbums.Count));
            assertCollection.Assert("Album should not be in the list", () => Assert.DoesNotContain(updatedAlbums, a => a.ArtistName == "The Beatles"));

            // Additional assertions to ensure the album and its CDs are deleted from the service
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "The Beatles" });
            updatedAlbums = _service.Response.List;
            assertCollection.Assert("Album should be deleted from the service", () => Assert.DoesNotContain(updatedAlbums, a => a.ArtistName == "The Beatles"));

            // Verify error list
            assertCollection.AssertErrorList("Error list should be empty", _service.Response.ErrorList);

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

            // Retrieve the updated list of albums
            var updatedAlbums = _service.Response.List;
            var savedAlbum = updatedAlbums.Find(a => a.ArtistName == "The Beatles");

            // Assert
            assertCollection.Assert("Album should still exist", () => Assert.NotNull(savedAlbum));
            var savedCD = savedAlbum.CDList.Find(cd => cd.Name == "Abbey Road");
            assertCollection.Assert("CD should still exist", () => Assert.NotNull(savedCD));
            assertCollection.Assert("Track should be removed from CD", () => Assert.DoesNotContain(savedCD.TrackList, t => t.Title == "Come Together"));

            // Additional assertions to ensure the track is deleted from the service
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "The Beatles", CdName = "Abbey Road" });
            var updatedCD = _service.Response.List.FirstOrDefault()?.CDList.FirstOrDefault();
            assertCollection.Assert("Track should be deleted from the service", () => Assert.DoesNotContain(updatedCD?.TrackList, t => t.Title == "Come Together"));

            // Verify error list
            assertCollection.AssertErrorList("Error list should be empty", _service.Response.ErrorList);

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

            // Additional assertions to check if the retrieved album matches the expected album details
            await _service.GetItemAsync(new BLL.Music.MusicSearchDTO { ArtistName = "Eminem" });
            assertCollection.Assert("Retrieved album should match the expected album", () => Assert.Equal("Eminem", _service.Response.Item.ArtistName));

            // Verify error list
            assertCollection.AssertErrorList("Error list should be empty", _service.Response.ErrorList);

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
            assertCollection.Assert("All albums should be retrieved", () => Assert.Equal(9, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            // Additional assertions to check if the retrieved albums match the expected album details
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            assertCollection.Assert("Retrieved albums should match the expected albums", () => Assert.Equal(9, _service.Response.List.Count));

            // Verify error list
            assertCollection.AssertErrorList("Error list should be empty", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsOneAlbumOneCD()
        {
            Initialize();
            var assertCollection = new AssertCollection("Fetching one album with one CD");

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "Daft Punk", CdName = "Discovery" });

            // Assert
            assertCollection.Assert("Should return one album", () => Assert.Single(_service.Response.List));
            assertCollection.Assert("The album should have one CD", () => Assert.Single(_service.Response.List.First().CDList));
            assertCollection.AssertErrorList("No errors should be present", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsOneAlbumTwoCD()
        {
            Initialize();
            var assertCollection = new AssertCollection("Fetching one album with two CDs");

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "Daft Punk" });

            // Assert
            assertCollection.Assert("Should return one album", () => Assert.Single(_service.Response.List));
            assertCollection.Assert("The album should have two CDs", () => Assert.Equal(2, _service.Response.List.First().CDList.Count));
            assertCollection.AssertErrorList("No errors should be present", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsAllCDs()
        {
            Initialize();
            var assertCollection = new AssertCollection("Fetching all CDs");

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            var allCDs = _service.Response.List.SelectMany(album => album.CDList).ToList();
            assertCollection.Assert("Should return all CDs", () => Assert.Equal(18, allCDs.Count));
            assertCollection.AssertErrorList("No errors should be present", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsAllTracks()
        {
            Initialize();
            var assertCollection = new AssertCollection("Fetching all tracks");

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());

            // Assert
            var allTracks = _service.Response.List
                .SelectMany(album => album.CDList)
                .SelectMany(cd => cd.TrackList)
                .ToList();
            assertCollection.Assert("Should return all tracks", () => Assert.Equal(211, allTracks.Count));
            assertCollection.AssertErrorList("No errors should be present", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsAllAlbumsWithGenre()
        {
            Initialize();
            var assertCollection = new AssertCollection("Fetching all albums with a specific genre");

            var genreDictionary = _context.Genres.ToDictionary(g => g.Description, g => g.ID);

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { GenreID = genreDictionary["Hip-Hop"] });

            // Assert
            var allAlbumsWithGenre = _service.Response.List;
            assertCollection.Assert("Should return all albums with the specified genre", () =>
            {
                Assert.All(allAlbumsWithGenre, album => Assert.True(album.CDList.Any(cd => cd.Genre_ID == genreDictionary["Hip-Hop"])));
            });
            assertCollection.AssertErrorList("No errors should be present", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ReturnsOneAlbumOneCDOneTrack()
        {
            Initialize();
            var assertCollection = new AssertCollection("Fetching one album with one CD and one track");

            // Act
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "Daft Punk", CdName = "Discovery", TrackTitle = "One More Time" });

            // Assert
            assertCollection.Assert("Should return one album", () => Assert.Single(_service.Response.List));
            assertCollection.Assert("The album should have one CD", () => Assert.Single(_service.Response.List.First().CDList));
            assertCollection.Assert("The CD should have one track", () => Assert.Single(_service.Response.List.First().CDList.First().TrackList, t => t.Title == "One More Time"));
            assertCollection.AssertErrorList("No errors should be present", _service.Response.ErrorList);

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
            assertCollection.Assert("New album should be added", () => Assert.Equal(10, _service.Response.List.Count));
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
                        Genre_ID = genreDictionary["Rock"],
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
            assertCollection.Assert("New album should be added", () => Assert.Equal(10, _service.Response.List.Count));
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
            assertCollection.Assert("Album should not be added due to missing CD title", () => Assert.Equal(9, _service.Response.List.Count));
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
            assertCollection.Assert("New album should be added", () => Assert.Equal(10, _service.Response.List.Count));
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
                        Genre_ID = genreDictionary["Rock"],
                        TrackList = new List<DTO.Music.Track>
                        {
                            new DTO.Music.Track { Number = 1, Title = "Track 1", Length = TimeSpan.FromMinutes(3.00) }
                        }
                    },
                    new DTO.Music.CD
                    {
                        Name = "CD2 with Genre",
                        Genre_ID = genreDictionary["Pop"],
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
            assertCollection.Assert("New album should be added", () => Assert.Equal(10, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            var savedAlbum = _service.Response.List.Find(a => a.ArtistName == "Artist with multiple CDs and genres");
            assertCollection.Assert("New album should be found", () => Assert.NotNull(savedAlbum));
            assertCollection.Assert("New album should have two CDs", () => Assert.Equal(2, savedAlbum.CDList.Count));
            assertCollection.Assert("First CD should have correct Genre_ID", () => Assert.Equal(genreDictionary["Rock"], savedAlbum.CDList[0].Genre_ID));
            assertCollection.Assert("Second CD should have correct Genre_ID", () => Assert.Equal(genreDictionary["Pop"], savedAlbum.CDList[1].Genre_ID));
            assertCollection.Verify();
        }
        [Fact]
        public async Task UpdateAlbum_InvalidArtistName_ShouldReturnError()
        {
            Initialize();
            var assertCollection = new AssertCollection("Invalid Artist Name");

            // Arrange
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO { ArtistName = "The Beatles" });
            var album = _service.Response.List.Find(a => a.ArtistName == "The Beatles");

            assertCollection.Assert("Album to update should exist", () => Assert.NotNull(album));

            if (album != null)
            {
                album.ArtistName = "";

                // Act
                await _service.SaveItemAsync(album);

                // Assert
                assertCollection.AssertErrorList("Error should be present for empty artist name", _service.Response.ErrorList);
            }

            assertCollection.Verify();
        }
    }
}