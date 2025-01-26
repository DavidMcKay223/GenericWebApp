using GenericWebApp.Model.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.UnitTest.Common
{
    public class ManagementDatabaseFixture : IDisposable
    {
        public Model.Management.ManagementContext Context { get; private set; }

        public ManagementDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<Model.Management.ManagementContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            Context = new Model.Management.ManagementContext(options);
            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();
        }

        public async Task SeedDataAsync()
        {
            Context.TaskItems.RemoveRange(Context.TaskItems);
            await Context.SaveChangesAsync();

            var tasksItem = new List<TaskItem>
            {
                new TaskItem { Title = "Task 1", Description = "Task 1 Description" },
                new TaskItem { Title = "Task 2", Description = "Task 2 Description" },
                new TaskItem { Title = "Task 3", Description = "Task 3 Description" }
            };

            Context.TaskItems.AddRange(tasksItem);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
