using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GenericWebApp.UnitTest.Music
{
    public class ServiceTest : IClassFixture<Common.AlbumDatabaseFixture>
    {
        private readonly Model.Music.AlbumContext _context;
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
        public async Task SaveItemAsync_SavesAlbumCorrectly2()
        {
            Initialize();

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "Eminem1", CDList = new List<DTO.Music.CD> { new DTO.Music.CD { Name = "The Marshall Mathers LP" } } };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            Assert.Equal(3, _service.Response.List.Count);
            Assert.Empty(_service.Response.ErrorList);

            await _service.GetItemAsync(new BLL.Music.MusicSearchDTO() { ArtistName = "Eminem" });

            // Assert
            var savedAlbum = _service.Response.Item;
            Assert.NotNull(savedAlbum);
            Assert.Empty(_service.Response.ErrorList);
            Assert.Equal("Eminem", savedAlbum.ArtistName);
            Assert.Single(savedAlbum.CDList);
            Assert.Equal("The Marshall Mathers LP", savedAlbum.CDList[0].Name);
        }

        [Fact]
        public async Task SaveItemAsync_SavesAlbumCorrectly()
        {
            Initialize();

            // Arrange
            var album = new DTO.Music.Album { ArtistName = "Eminem1", CDList = new List<DTO.Music.CD> { new DTO.Music.CD { Name = "The Marshall Mathers LP" } } };

            // Act
            await _service.SaveItemAsync(album);
            await _service.GetListAsync(new BLL.Music.MusicSearchDTO());
            Assert.Equal(3, _service.Response.List.Count);
            Assert.Empty(_service.Response.ErrorList);

            await _service.GetItemAsync(new BLL.Music.MusicSearchDTO() { ArtistName = "Eminem" });

            // Assert
            var savedAlbum = _service.Response.Item;
            Assert.NotNull(savedAlbum);
            Assert.Empty(_service.Response.ErrorList);
            Assert.Equal("Eminem", savedAlbum.ArtistName);
            Assert.Single(savedAlbum.CDList);
            Assert.Equal("The Marshall Mathers LP", savedAlbum.CDList[0].Name);
        }
    }
}
