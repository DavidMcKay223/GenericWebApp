using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using GenericWebApp.BLL.Common;
using GenericWebApp.DTO.Common;
using GenericWebApp.DTO.Template;
using GenericWebApp.Model.Template;
using Microsoft.EntityFrameworkCore;
using GenericWebApp.UnitTest.Common;
using System.Linq;
using GenericWebApp.BLL.Template;
using GenericWebApp.Model.Music;

namespace GenericWebApp.UnitTest.Template
{
    public class TemplateServiceTest : IClassFixture<GenericWebApp.UnitTest.Common.DatabaseFixtureTemplate>, IAsyncLifetime
    {
        private readonly TemplateContext _context;
        private readonly GenericWebApp.BLL.Template.TemplateService _service;
        private readonly Common.DatabaseFixtureTemplate _fixture;

        public TemplateServiceTest(DatabaseFixtureTemplate fixture)
        {
            _context = fixture.Context;
            _service = new BLL.Template.TemplateService(_context) { Response = new Response<DTO.Template.TemplateItem>() { ErrorList = [] } };
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
        public async Task GetListAsync_ReturnsAllTemplates()
        {
            var assertCollection = new AssertCollection("Retrieving all templates");

            // Act
            await _service.GetListAsync(new TemplateSearchDTO());

            // Assert
            assertCollection.Assert("All templates should be retrieved", () => Assert.True(_service.Response.List!.Count > 0));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_TemplateWithTitleAndDescription()
        {
            var assertCollection = new AssertCollection("Saving template with title and description");

            // Arrange
            var template = new DTO.Template.TemplateItem
            {
                Title = "New Template",
                Description = "New Template Description",
                PrimaryAddress = new DTO.Template.TemplateAddress(),
                SecondaryAddress = new DTO.Template.TemplateAddress(),
                IsCompleted = false
            };

            // Act
            await _service.SaveItemAsync(template);
            await _service.GetListAsync(new TemplateSearchDTO());

            // Assert
            assertCollection.Assert("New template should be added", () => Assert.Contains(_service.Response.List!, t => t.Title == "New Template"));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        //[Fact]
        //public async Task GetItemAsync_ReturnsCorrectTemplate()
        //{
        //    var assertCollection = new AssertCollection("Retrieving correct template");

        //    // Arrange
        //    var searchParams = new TemplateSearchDTO() { Title = "Template 1" };

        //    // Act
        //    await _service.GetItemAsync(searchParams);

        //    // Assert
        //    assertCollection.Assert("Template should be retrieved", () => Assert.NotNull(_service.Response.Item));
        //    assertCollection.Assert("Template title should be 'New Template'", () => Assert.Equal("Template 1", _service.Response.Item!.Title));
        //    assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

        //    assertCollection.Verify();
        //}

        //[Fact]
        //public async Task DeleteItemAsync_DeletesTemplateCorrectly()
        //{
        //    var assertCollection = new AssertCollection("Deleting template correctly");

        //    // Arrange
        //    await _service.GetListAsync(new TemplateSearchDTO());
        //    var template = _service.Response.List!.First(x => x.Title == "Template 1");

        //    // Act
        //    await _service.DeleteItemAsync(new DTO.Template.TemplateItem { ID = template.ID, Description = String.Empty, IsCompleted = false, PrimaryAddress = new DTO.Template.TemplateAddress(), SecondaryAddress = new DTO.Template.TemplateAddress(), Title = String.Empty });
        //    await _service.GetListAsync(new TemplateSearchDTO());

        //    // Assert
        //    assertCollection.Assert("Template should be deleted", () => Assert.DoesNotContain(_service.Response.List!, t => t.ID == template.ID));
        //    assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

        //    assertCollection.Verify();
        //}

        [Fact]
        public async Task GetListAsync_WithPagination_ReturnsCorrectTemplates()
        {
            var assertCollection = new AssertCollection("Retrieving templates with pagination");

            // Act
            await _service.GetListAsync(new TemplateSearchDTO { PageNumber = 0, PageSize = 2 });

            // Assert
            assertCollection.Assert("Two templates should be retrieved", () => Assert.Equal(2, _service.Response.List!.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ByCompletionStatus_ReturnsCorrectTemplates()
        {
            var assertCollection = new AssertCollection("Retrieving templates by completion status");

            // Act
            await _service.GetListAsync(new TemplateSearchDTO { IsCompleted = true });

            // Assert
            assertCollection.Assert("Only completed templates should be retrieved", () => Assert.All(_service.Response.List ?? [], t => Assert.True(t.IsCompleted)));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_WithInvalidTemplate_ReturnsValidationError()
        {
            var assertCollection = new AssertCollection("Saving invalid template");

            // Arrange
            var template = new DTO.Template.TemplateItem
            {
                Title = "",
                Description = "",
                PrimaryAddress = new DTO.Template.TemplateAddress(),
                SecondaryAddress = new DTO.Template.TemplateAddress(),
                IsCompleted = false
            };

            // Act
            await _service.SaveItemAsync(template);

            // Assert
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_WithValidID_ReturnsCorrectTemplate()
        {
            var assertCollection = new AssertCollection("Retrieving template by valid ID");

            // Arrange
            var template = _context.TemplateItems.First();

            // Act
            await _service.GetItemAsync(new TemplateSearchDTO { ID = template.ID });

            // Assert
            assertCollection.Assert("Template should be retrieved", () => Assert.NotNull(_service.Response.Item));
            assertCollection.Assert("Template ID should match", () => Assert.Equal(template.ID, _service.Response.Item!.ID));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_WithUpdatedTemplate_UpdatesTemplateCorrectly()
        {
            var assertCollection = new AssertCollection("Updating existing template");

            // Arrange
            await _service.GetListAsync(new TemplateSearchDTO());
            var template = _service.Response.List!.First();
            template!.Title = "Updated Template Title";

            // Act
            await _service.SaveItemAsync(template);
            await _service.GetListAsync(new TemplateSearchDTO());

            // Assert
            assertCollection.Assert("Template should be updated", () => Assert.Contains(_service.Response.List ?? [], t => t.Title == "Updated Template Title"));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_WithNonExistentID_ReturnsError()
        {
            var assertCollection = new AssertCollection("Deleting template with non-existent ID");

            // Act
            await _service.DeleteItemAsync(new DTO.Template.TemplateItem
            {
                ID = -1,
                Title = "Dummy Title",
                Description = "Dummy Description",
                PrimaryAddress = new DTO.Template.TemplateAddress(),
                SecondaryAddress = new DTO.Template.TemplateAddress(),
                IsCompleted = false
            });

            // Assert
            assertCollection.AssertErrorList("Error list should contain deletion failure error", _service.Response.ErrorList);

            assertCollection.Verify();
        }
    }
}
