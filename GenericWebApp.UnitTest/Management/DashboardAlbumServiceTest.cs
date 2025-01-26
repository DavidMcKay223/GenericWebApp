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
using GenericWebApp.BLL.Music;


namespace GenericWebApp.UnitTest.Management
{
    public class DashboardAlbumServiceTest : IClassFixture<Common.AlbumDatabaseFixture>, IAsyncLifetime
    {
        private readonly AlbumContext _context;
        private readonly BLL.Management.DashboardAlbumService _service;
        private readonly Common.AlbumDatabaseFixture _fixture;

        public DashboardAlbumServiceTest(Common.AlbumDatabaseFixture fixture)
        {
            _context = fixture.Context;
            _service = new BLL.Management.DashboardAlbumService(_context);
            _fixture = fixture;
        }

        public async Task InitializeAsync()
        {
            await _fixture.SeedDataAsync();
        }

        public Task DisposeAsync()
        {
            // Cleanup if necessary
            return Task.CompletedTask;
        }

        [Fact]
        public async Task GetDashboardMusicSummary_DisplaysEachGenre()
        {
            var assertCollection = new AssertCollection("Displaying each genre");

            // Act
            var result = _service.GetDashboardMusicSummary();

            // Assert
            var genres = await _context.Genres.Select(g => g.Description).ToListAsync(); // Ensure async call
            assertCollection.Assert("Genre count should match", () => Assert.Equal(genres.Count, result.Count));
            foreach (var genre in genres)
            {
                assertCollection.Assert($"Genre '{genre}' should be in the result", () => Assert.Contains(result, r => r.GenreName == genre));
            }

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetDashboardMusicSummary_CalculatesTotalSumOfEachField()
        {
            var assertCollection = new AssertCollection("Calculating total sum of each field");

            // Act
            var result = _service.GetDashboardMusicSummary();
            
            // Assert
            var totalAlbumCount = await _context.Albums.CountAsync();
            var totalCDCount = await _context.CDs.CountAsync();
            var totalTrackCount = await _context.Tracks.CountAsync();
            //var totalTrackLength = await _context.Tracks.SumAsync(t => t.Length.Ticks);

            assertCollection.Assert("Total album count should match", () => Assert.Equal(totalAlbumCount, result.Sum(r => r.AlbumCount)));
            assertCollection.Assert("Total CD count should match", () => Assert.Equal(totalCDCount, result.Sum(r => r.CDCount)));
            assertCollection.Assert("Total track count should match", () => Assert.Equal(totalTrackCount, result.Sum(r => r.TotalTrackCount)));
            //assertCollection.Assert("Total track length should match", () => Assert.Equal(totalTrackLength, result.Sum(r => r.TotalTrackLength.Ticks)));

            assertCollection.Verify();
        }
    }
}
