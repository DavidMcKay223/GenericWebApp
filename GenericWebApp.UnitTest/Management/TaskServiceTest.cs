using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using GenericWebApp.BLL.Common;
using GenericWebApp.DTO.Common;
using GenericWebApp.DTO.Management;
using GenericWebApp.Model.Management;
using Microsoft.EntityFrameworkCore;
using GenericWebApp.UnitTest.Common;
using System.Linq;
using GenericWebApp.BLL.Management;
using GenericWebApp.Model.Music;

namespace GenericWebApp.UnitTest.Management
{
    public class TaskServiceTest : IClassFixture<Common.ManagementDatabaseFixture>
    {
        private readonly ManagementContext _context;
        private readonly BLL.Management.TaskService _service;
        private readonly Common.ManagementDatabaseFixture _fixture;

        public TaskServiceTest(Common.ManagementDatabaseFixture fixture)
        {
            _context = fixture.Context;
            _service = new BLL.Management.TaskService(_context);
            _fixture = fixture;
        }

        public void Initialize()
        {
            _fixture.SeedData();
        }

        [Fact]
        public async Task GetListAsync_ReturnsAllTasks()
        {
            Initialize();
            var assertCollection = new AssertCollection("Retrieving all tasks");

            // Act
            await _service.GetListAsync(new TaskSeachDTO());

            // Assert
            assertCollection.Assert("All tasks should be retrieved", () => Assert.Equal(3, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_TaskWithTitleAndDescription()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving task with title and description");

            // Arrange
            var task = new DTO.Management.TaskItem { Title = "New Task", Description = "New Task Description" };

            // Act
            await _service.SaveItemAsync(task);
            await _service.GetListAsync(new TaskSeachDTO());

            // Assert
            assertCollection.Assert("New task should be added", () => Assert.Equal(4, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));
            assertCollection.Assert("New task should be in the list", () => Assert.Contains(_service.Response.List, t => t.Title == "New Task"));

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_DeletesTaskCorrectly()
        {
            Initialize();
            var assertCollection = new AssertCollection("Deleting task correctly");

            // Arrange
            var task = _context.TaskItems.FirstOrDefault(t => t.Title == "Task 1");

            // Act
            await _service.DeleteItemAsync(new DTO.Management.TaskItem { ID = task.ID });
            await _service.GetListAsync(new TaskSeachDTO());

            // Retrieve the updated list of tasks
            var updatedTasks = _service.Response.List;

            // Assert
            assertCollection.Assert("Task should be deleted", () => Assert.DoesNotContain(updatedTasks, t => t.ID == task.ID));
            assertCollection.AssertErrorList("Error list should be empty", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_ReturnsCorrectTask()
        {
            Initialize();
            var assertCollection = new AssertCollection("Retrieving correct task");

            // Arrange
            var searchParams = new TaskSeachDTO() { TaskTitle = "Task 1" };

            // Act
            await _service.GetItemAsync(searchParams);

            // Assert
            assertCollection.Assert("Task should be retrieved", () => Assert.NotNull(_service.Response.Item));
            assertCollection.Assert("Task title should be 'Task 1'", () => Assert.Equal("Task 1", _service.Response.Item.Title));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_InvalidTask_ShouldReturnError()
        {
            Initialize();
            var assertCollection = new AssertCollection("Saving invalid task");

            // Arrange
            var task = new DTO.Management.TaskItem { Title = "", Description = "" };

            // Act
            await _service.SaveItemAsync(task);
            await _service.GetListAsync(new TaskSeachDTO());

            // Assert
            assertCollection.Assert("Task should not be added due to validation errors", () => Assert.Equal(3, _service.Response.List.Count));
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }
    }
}
