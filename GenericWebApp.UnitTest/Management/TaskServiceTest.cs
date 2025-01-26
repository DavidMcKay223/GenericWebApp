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
    public class TaskServiceTest : IClassFixture<Common.ManagementDatabaseFixture>, IAsyncLifetime
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
        public async Task GetListAsync_ReturnsAllTasks()
        {
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

        [Fact]
        public async Task GetListAsync_WithEmptySearchParams_ReturnsAllTasks()
        {
            var assertCollection = new AssertCollection("Retrieving all tasks with empty search params");

            // Act
            await _service.GetListAsync(new TaskSeachDTO());

            // Assert
            assertCollection.Assert("All tasks should be retrieved", () => Assert.Equal(3, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_WithPagination_ReturnsCorrectTasks()
        {
            var assertCollection = new AssertCollection("Retrieving tasks with pagination");

            // Act
            await _service.GetListAsync(new TaskSeachDTO { PageNumber = 1, PageSize = 2 });

            // Assert
            assertCollection.Assert("Two tasks should be retrieved", () => Assert.Equal(2, _service.Response.List.Count));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetListAsync_ByDateRange_ReturnsCorrectTasks()
        {
            var assertCollection = new AssertCollection("Retrieving tasks by date range");

            // Act
            await _service.GetListAsync(new TaskSeachDTO { CreatedDate = DateTime.UtcNow.AddDays(-7), UpdatedDate = DateTime.UtcNow });

            // Assert
            assertCollection.Assert("Tasks within date range should be retrieved", () => Assert.All(_service.Response.List, t => Assert.True(t.CreatedDate >= DateTime.UtcNow.AddDays(-7) && t.UpdatedDate <= DateTime.UtcNow)));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }
        [Fact]
        public async Task GetListAsync_WithInvalidParams_ReturnsError()
        {
            var assertCollection = new AssertCollection("Retrieving tasks with invalid params");

            // Act
            await _service.GetListAsync(new TaskSeachDTO { TaskTitle = null });

            // Assert
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_WithValidID_ReturnsCorrectTask()
        {
            var assertCollection = new AssertCollection("Retrieving task by valid ID");

            // Arrange
            var task = _context.TaskItems.First();

            // Act
            await _service.GetItemAsync(new TaskSeachDTO { ID = task.ID });

            // Assert
            assertCollection.Assert("Task should be retrieved", () => Assert.NotNull(_service.Response.Item));
            assertCollection.Assert("Task ID should match", () => Assert.Equal(task.ID, _service.Response.Item.ID));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_WithNonExistentID_ReturnsNull()
        {
            var assertCollection = new AssertCollection("Retrieving task by non-existent ID");

            // Act
            await _service.GetItemAsync(new TaskSeachDTO { ID = -1 });

            // Assert
            assertCollection.Assert("Task should not be retrieved", () => Assert.Null(_service.Response.Item));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_ByPartialTitle_ReturnsCorrectTask()
        {
            var assertCollection = new AssertCollection("Retrieving task by partial title");

            // Act
            await _service.GetItemAsync(new TaskSeachDTO { TaskTitle = "Task" });

            // Assert
            assertCollection.Assert("Task should be retrieved", () => Assert.NotNull(_service.Response.Item));
            assertCollection.Assert("Task title should contain 'Task'", () => Assert.Contains("Task", _service.Response.Item.Title));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task GetItemAsync_WithInvalidParams_ReturnsError()
        {
            var assertCollection = new AssertCollection("Retrieving task with invalid params");

            // Act
            await _service.GetItemAsync(new TaskSeachDTO { TaskTitle = null });

            // Assert
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_WithValidTask_AddsTaskSuccessfully()
        {
            var assertCollection = new AssertCollection("Saving valid task");

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
        public async Task SaveItemAsync_WithEmptyTitle_ReturnsValidationError()
        {
            var assertCollection = new AssertCollection("Saving task with empty title");

            // Arrange
            var task = new DTO.Management.TaskItem { Title = "", Description = "Description" };

            // Act
            await _service.SaveItemAsync(task);

            // Assert
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_WithEmptyDescription_ReturnsValidationError()
        {
            var assertCollection = new AssertCollection("Saving task with empty description");

            // Arrange
            var task = new DTO.Management.TaskItem { Title = "Title", Description = "" };

            // Act
            await _service.SaveItemAsync(task);

            // Assert
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_WithDuplicateTask_ReturnsError()
        {
            var assertCollection = new AssertCollection("Saving duplicate task");

            // Arrange
            var task = new DTO.Management.TaskItem { Title = "Task 1", Description = "Duplicate Task Description" };

            // Act
            await _service.SaveItemAsync(task);

            // Assert
            assertCollection.AssertErrorList("Error list should contain duplication errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task SaveItemAsync_WithUpdatedTask_UpdatesTaskCorrectly()
        {
            var assertCollection = new AssertCollection("Updating existing task");

            // Arrange
            var task = _context.TaskItems.First();
            task.Title = "Updated Task Title";

            // Act
            await _service.SaveItemAsync(Model.Common.ManagementParser.ParseDTO(task));
            await _service.GetListAsync(new TaskSeachDTO());

            // Assert
            assertCollection.Assert("Task should be updated", () => Assert.Contains(_service.Response.List, t => t.Title == "Updated Task Title"));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_WithValidID_DeletesTaskSuccessfully()
        {
            var assertCollection = new AssertCollection("Deleting task with valid ID");

            // Arrange
            var task = _context.TaskItems.First();

            // Act
            await _service.DeleteItemAsync(new DTO.Management.TaskItem { ID = task.ID });
            await _service.GetListAsync(new TaskSeachDTO());

            // Assert
            assertCollection.Assert("Task should be deleted", () => Assert.DoesNotContain(_service.Response.List, t => t.ID == task.ID));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_WithNonExistentID_ReturnsError()
        {
            var assertCollection = new AssertCollection("Deleting task with non-existent ID");

            // Act
            await _service.DeleteItemAsync(new DTO.Management.TaskItem { ID = -1 });

            // Assert
            assertCollection.AssertErrorList("Error list should contain deletion failure error", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_WithInvalidID_ReturnsError()
        {
            var assertCollection = new AssertCollection("Deleting task with invalid ID");

            // Act
            await _service.DeleteItemAsync(new DTO.Management.TaskItem { ID = null });

            // Assert
            assertCollection.AssertErrorList("Error list should contain validation errors", _service.Response.ErrorList);

            assertCollection.Verify();
        }

        [Fact]
        public async Task DeleteItemAsync_WithConcurrentUpdates_HandlesGracefully()
        {
            var assertCollection = new AssertCollection("Deleting task with concurrent updates");

            // Arrange
            var task = _context.TaskItems.First();
            var concurrentTask = _context.TaskItems.First();

            // Act
            await _service.DeleteItemAsync(new DTO.Management.TaskItem { ID = task.ID });
            concurrentTask.Title = "Concurrent Update";
            await _context.SaveChangesAsync();

            // Assert
            assertCollection.Assert("Task should be deleted", () => Assert.DoesNotContain(_service.Response.List, t => t.ID == task.ID));
            assertCollection.Assert("Error list should be empty", () => Assert.Empty(_service.Response.ErrorList));

            assertCollection.Verify();
        }
    }
}
