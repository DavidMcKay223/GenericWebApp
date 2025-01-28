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

namespace GenericWebApp.UnitTest.Template
{
    public class TemplateServiceTest : IClassFixture<Common.DatabaseFixtureTemplate>, IAsyncLifetime
    {
        private readonly AlbumContext _context;
        private readonly BLL.Management.DashboardAlbumService _service;
        private readonly Common.DatabaseFixtureAlbum _fixture;

        public TemplateServiceTest(Common.DatabaseFixtureAlbum fixture)
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
    }
}
