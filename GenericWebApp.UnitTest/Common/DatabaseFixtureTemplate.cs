using GenericWebApp.Model.Management;
using GenericWebApp.Model.Template;
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
            if (!Context.TemplateItems.Any())
            {
                var templates = new List<TemplateItem>
                {
                    new TemplateItem
                    {
                        Title = "Template 1",
                        Description = "Description for Template 1",
                        PrimaryAddress = new TemplateAddress { Address1 = "123 Main St", City = "City1", State = "State1", Zip = "12345" },
                        SecondaryAddress = new TemplateAddress { Address1 = "456 Side St", City = "City2", State = "State2", Zip = "67890" },
                        IsCompleted = true
                    },
                    new TemplateItem
                    {
                        Title = "Template 2",
                        Description = "Description for Template 2",
                        PrimaryAddress = new TemplateAddress { Address1 = "789 Oak St", City = "City3", State = "State3", Zip = "13579" },
                        SecondaryAddress = new TemplateAddress { Address1 = "101 Pine St", City = "City4", State = "State4", Zip = "24680" },
                        IsCompleted = false
                    },
                    new TemplateItem
                    {
                        Title = "Template 3",
                        Description = "Description for Template 3",
                        PrimaryAddress = new TemplateAddress { Address1 = "246 Elm St", City = "City5", State = "State5", Zip = "97531" },
                        SecondaryAddress = new TemplateAddress { Address1 = "369 Maple St", City = "City6", State = "State6", Zip = "86420" },
                        IsCompleted = true
                    },
                    new TemplateItem
                    {
                        Title = "Template 4",
                        Description = "Description for Template 4",
                        PrimaryAddress = new TemplateAddress { Address1 = "135 Cedar St", City = "City7", State = "State7", Zip = "75319" },
                        SecondaryAddress = new TemplateAddress { Address1 = "579 Birch St", City = "City8", State = "State8", Zip = "95173" },
                        IsCompleted = false
                    }
                };

                Context.TemplateItems.AddRange(templates);
                await Context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
