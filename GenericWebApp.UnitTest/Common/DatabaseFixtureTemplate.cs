using GenericWebApp.Model.Management;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.UnitTest.Common
{
    public class DatabaseFixtureTemplate : IDisposable
    {
        public Model.Template.TemplateContext Context { get; private set; }

        public DatabaseFixtureTemplate()
        {
            var options = new DbContextOptionsBuilder<Model.Template.TemplateContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;

            Context = new Model.Template.TemplateContext(options);
            Context.Database.OpenConnection();
            Context.Database.EnsureCreated();
        }

        public async Task SeedDataAsync()
        {
            Context.TemplateItems.RemoveRange(Context.TemplateItems);
            await Context.SaveChangesAsync();

            var templateItems = new List<Model.Template.TemplateItem>
            {
                new() { Title = "Template 1", Description = "Template 1 Description", IsCompleted = false, TemplateStatus_ID = 1, PrimaryAddress = new Model.Template.TemplateAddress(), SecondaryAddress = new Model.Template.TemplateAddress() },
                new() { Title = "Template 2", Description = "Template 2 Description", IsCompleted = false, TemplateStatus_ID = 1, PrimaryAddress = new Model.Template.TemplateAddress(), SecondaryAddress = new Model.Template.TemplateAddress() },
                new() { Title = "Template 3", Description = "Template 3 Description", IsCompleted = true, TemplateStatus_ID = 1, PrimaryAddress = new Model.Template.TemplateAddress(), SecondaryAddress = new Model.Template.TemplateAddress() }
            };

            Context.TemplateItems.AddRange(templateItems);
            await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
