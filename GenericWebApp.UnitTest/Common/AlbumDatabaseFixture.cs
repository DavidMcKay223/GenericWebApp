using GenericWebApp.Model.Music;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.UnitTest.Common
{
    public class AlbumDatabaseFixture : IDisposable
    {
        public Model.Music.AlbumContext Context { get; private set; }

        public AlbumDatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<Model.Music.AlbumContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            Context = new Model.Music.AlbumContext(options);
            SeedData();
        }

        public void SeedData()
        {
            Context.Albums.RemoveRange(Context.Albums);
            Context.SaveChanges();

            Context.Albums.Add(new Album { ArtistName = "Eminem", CDList = new List<CD> { new CD { Name = "The Marshall Mathers LP" } } });
            Context.Albums.Add(new Album { ArtistName = "The Beatles", CDList = new List<CD> { new CD { Name = "Abbey Road" } } });
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
