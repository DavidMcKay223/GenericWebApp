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

            if (Context.Genres.Count() == 0)
            {
                // Create and add genres
                var genres = new List<Genre>
                {
                    new Genre { Description = "Rock" },
                    new Genre { Description = "Pop" },
                    new Genre { Description = "Jazz" },
                    new Genre { Description = "Classical" },
                    new Genre { Description = "Hip-Hop" },
                    new Genre { Description = "Electronic" },
                    new Genre { Description = "Country" },
                    new Genre { Description = "Reggae" },
                    new Genre { Description = "Blues" },
                    new Genre { Description = "Metal" }
                };

                Context.Genres.AddRange(genres);
                Context.SaveChanges();
            }

            // Retrieve the genre IDs from the database
            var genreDictionary = Context.Genres.ToDictionary(g => g.Description, g => g.ID);

            // Create and add albums, CDs, and tracks
            var albums = new List<Album>
            {
                new Album
                {
                    ArtistName = "The Beatles",
                    CDList = new List<CD>
                    {
                        new CD
                        {
                            Name = "Abbey Road",
                            Genre_ID = genreDictionary["Rock"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Come Together", Length = TimeSpan.FromMinutes(4.33) },
                                new Track { Number = 2, Title = "Something", Length = TimeSpan.FromMinutes(3.03) },
                                new Track { Number = 3, Title = "Maxwell's Silver Hammer", Length = TimeSpan.FromMinutes(3.27) },
                                new Track { Number = 4, Title = "Oh! Darling", Length = TimeSpan.FromMinutes(3.26) },
                                new Track { Number = 5, Title = "Octopus's Garden", Length = TimeSpan.FromMinutes(2.51) },
                                new Track { Number = 6, Title = "I Want You (She's So Heavy)", Length = TimeSpan.FromMinutes(7.47) },
                                new Track { Number = 7, Title = "Here Comes the Sun", Length = TimeSpan.FromMinutes(3.06) },
                                new Track { Number = 8, Title = "Because", Length = TimeSpan.FromMinutes(2.45) },
                                new Track { Number = 9, Title = "You Never Give Me Your Money", Length = TimeSpan.FromMinutes(4.02) },
                                new Track { Number = 10, Title = "Sun King", Length = TimeSpan.FromMinutes(2.26) },
                                new Track { Number = 11, Title = "Mean Mr. Mustard", Length = TimeSpan.FromMinutes(1.06) },
                                new Track { Number = 12, Title = "Polythene Pam", Length = TimeSpan.FromMinutes(1.12) },
                                new Track { Number = 13, Title = "She Came In Through the Bathroom Window", Length = TimeSpan.FromMinutes(1.57) },
                                new Track { Number = 14, Title = "Golden Slumbers", Length = TimeSpan.FromMinutes(1.31) },
                                new Track { Number = 15, Title = "Carry That Weight", Length = TimeSpan.FromMinutes(1.37) },
                                new Track { Number = 16, Title = "The End", Length = TimeSpan.FromMinutes(2.20) },
                                new Track { Number = 17, Title = "Her Majesty", Length = TimeSpan.FromMinutes(0.23) }
                            }
                        },
                        new CD
                        {
                            Name = "Sgt. Pepper's Lonely Hearts Club Band",
                            Genre_ID = genreDictionary["Rock"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Sgt. Pepper's Lonely Hearts Club Band", Length = TimeSpan.FromMinutes(2.02) },
                                new Track { Number = 2, Title = "With a Little Help from My Friends", Length = TimeSpan.FromMinutes(2.44) },
                                new Track { Number = 3, Title = "Lucy in the Sky with Diamonds", Length = TimeSpan.FromMinutes(3.28) },
                                new Track { Number = 4, Title = "Getting Better", Length = TimeSpan.FromMinutes(2.47) },
                                new Track { Number = 5, Title = "Fixing a Hole", Length = TimeSpan.FromMinutes(2.36) },
                                new Track { Number = 6, Title = "She's Leaving Home", Length = TimeSpan.FromMinutes(3.35) },
                                new Track { Number = 7, Title = "Being for the Benefit of Mr. Kite!", Length = TimeSpan.FromMinutes(2.37) },
                                new Track { Number = 8, Title = "Within You Without You", Length = TimeSpan.FromMinutes(5.05) },
                                new Track { Number = 9, Title = "When I'm Sixty-Four", Length = TimeSpan.FromMinutes(2.37) },
                                new Track { Number = 10, Title = "Lovely Rita", Length = TimeSpan.FromMinutes(2.42) },
                                new Track { Number = 11, Title = "Good Morning Good Morning", Length = TimeSpan.FromMinutes(2.41) },
                                new Track { Number = 12, Title = "Sgt. Pepper's Lonely Hearts Club Band (Reprise)", Length = TimeSpan.FromMinutes(1.18) },
                                new Track { Number = 13, Title = "A Day in the Life", Length = TimeSpan.FromMinutes(5.33) }
                            }
                        }
                    }
                },
                new Album
                {
                    ArtistName = "Daft Punk",
                    CDList = new List<CD>
                    {
                        new CD
                        {
                            Name = "Random Access Memories",
                            Genre_ID = genreDictionary["Electronic"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Give Life Back to Music", Length = TimeSpan.FromMinutes(4.34) },
                                new Track { Number = 2, Title = "The Game of Love", Length = TimeSpan.FromMinutes(5.21) },
                                new Track { Number = 3, Title = "Giorgio by Moroder", Length = TimeSpan.FromMinutes(9.05) },
                                new Track { Number = 4, Title = "Within", Length = TimeSpan.FromMinutes(3.48) },
                                new Track { Number = 5, Title = "Instant Crush", Length = TimeSpan.FromMinutes(5.37) },
                                new Track { Number = 6, Title = "Lose Yourself to Dance", Length = TimeSpan.FromMinutes(5.53) },
                                new Track { Number = 7, Title = "Touch", Length = TimeSpan.FromMinutes(8.18) },
                                new Track { Number = 8, Title = "Get Lucky", Length = TimeSpan.FromMinutes(6.09) },
                                new Track { Number = 9, Title = "Beyond", Length = TimeSpan.FromMinutes(4.50) },
                                new Track { Number = 10, Title = "Motherboard", Length = TimeSpan.FromMinutes(5.41) },
                                new Track { Number = 11, Title = "Fragments of Time", Length = TimeSpan.FromMinutes(4.39) },
                                new Track { Number = 12, Title = "Doin' It Right", Length = TimeSpan.FromMinutes(4.11) },
                                new Track { Number = 13, Title = "Contact", Length = TimeSpan.FromMinutes(6.21) }
                            }
                        },
                        new CD
                        {
                            Name = "Discovery",
                            Genre_ID = genreDictionary["Electronic"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "One More Time", Length = TimeSpan.FromMinutes(5.20) },
                                new Track { Number = 2, Title = "Aerodynamic", Length = TimeSpan.FromMinutes(3.27) },
                                new Track { Number = 3, Title = "Digital Love", Length = TimeSpan.FromMinutes(4.58) },
                                new Track { Number = 4, Title = "Harder, Better, Faster, Stronger", Length = TimeSpan.FromMinutes(3.44) },
                                new Track { Number = 5, Title = "Crescendolls", Length = TimeSpan.FromMinutes(3.31) },
                                new Track { Number = 6, Title = "Nightvision", Length = TimeSpan.FromMinutes(1.44) },
                                new Track { Number = 7, Title = "Superheroes", Length = TimeSpan.FromMinutes(3.57) },
                                new Track { Number = 8, Title = "High Life", Length = TimeSpan.FromMinutes(3.22) },
                                new Track { Number = 9, Title = "Something About Us", Length = TimeSpan.FromMinutes(3.51) },
                                new Track { Number = 10, Title = "Voyager", Length = TimeSpan.FromMinutes(3.47) },
                                new Track { Number = 11, Title = "Veridis Quo", Length = TimeSpan.FromMinutes(5.44) },
                                new Track { Number = 12, Title = "Short Circuit", Length = TimeSpan.FromMinutes(3.26) },
                                new Track { Number = 13, Title = "Face to Face", Length = TimeSpan.FromMinutes(3.58) },
                                new Track { Number = 14, Title = "Too Long", Length = TimeSpan.FromMinutes(10.00) }
                            }
                        }
                    }
                },

                new Album
                {
                    ArtistName = "Beyoncé",
                    CDList = new List<CD>
                    {
                        new CD
                        {
                            Name = "Lemonade",
                            Genre_ID = genreDictionary["Pop"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Pray You Catch Me", Length = TimeSpan.FromMinutes(3.16) },
                                new Track { Number = 2, Title = "Hold Up", Length = TimeSpan.FromMinutes(3.41) },
                                new Track { Number = 3, Title = "Don't Hurt Yourself", Length = TimeSpan.FromMinutes(3.54) },
                                new Track { Number = 4, Title = "Sorry", Length = TimeSpan.FromMinutes(3.53) },
                                new Track { Number = 5, Title = "6 Inch", Length = TimeSpan.FromMinutes(4.20) },
                                new Track { Number = 6, Title = "Daddy Lessons", Length = TimeSpan.FromMinutes(4.47) },
                                new Track { Number = 7, Title = "Love Drought", Length = TimeSpan.FromMinutes(3.57) },
                                new Track { Number = 8, Title = "Sandcastles", Length = TimeSpan.FromMinutes(3.02) },
                                new Track { Number = 9, Title = "Forward", Length = TimeSpan.FromMinutes(1.19) },
                                new Track { Number = 10, Title = "Freedom", Length = TimeSpan.FromMinutes(4.50) },
                                new Track { Number = 11, Title = "All Night", Length = TimeSpan.FromMinutes(5.22) },
                                new Track { Number = 12, Title = "Formation", Length = TimeSpan.FromMinutes(3.26) }
                            }
                        },
                        new CD
                        {
                            Name = "Beyoncé",
                            Genre_ID = genreDictionary["Pop"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Pretty Hurts", Length = TimeSpan.FromMinutes(4.17) },
                                new Track { Number = 2, Title = "Haunted", Length = TimeSpan.FromMinutes(6.09) },
                                new Track { Number = 3, Title = "Drunk in Love", Length = TimeSpan.FromMinutes(5.23) },
                                new Track { Number = 4, Title = "Blow", Length = TimeSpan.FromMinutes(5.09) },
                                new Track { Number = 5, Title = "No Angel", Length = TimeSpan.FromMinutes(3.48) },
                                new Track { Number = 6, Title = "Partition", Length = TimeSpan.FromMinutes(5.19) },
                                new Track { Number = 7, Title = "Jealous", Length = TimeSpan.FromMinutes(3.04) },
                                new Track { Number = 8, Title = "Rocket", Length = TimeSpan.FromMinutes(6.31) },
                                new Track { Number = 9, Title = "Mine", Length = TimeSpan.FromMinutes(6.18) },
                                new Track { Number = 10, Title = "XO", Length = TimeSpan.FromMinutes(3.36) },
                                new Track { Number = 11, Title = "Flawless", Length = TimeSpan.FromMinutes(4.10) },
                                new Track { Number = 12, Title = "Superpower", Length = TimeSpan.FromMinutes(4.36) },
                                new Track { Number = 13, Title = "Heaven", Length = TimeSpan.FromMinutes(3.50) },
                                new Track { Number = 14, Title = "Blue", Length = TimeSpan.FromMinutes(4.26) }
                            }
                        }
                    }
                },

                new Album
                {
                    ArtistName = "Eminem",
                    CDList = new List<CD>
                    {
                        new CD
                        {
                            Name = "The Marshall Mathers LP",
                            Genre_ID = genreDictionary["Hip-Hop"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Public Service Announcement 2000", Length = TimeSpan.FromMinutes(0.25) },
                                new Track { Number = 2, Title = "Kill You", Length = TimeSpan.FromMinutes(4.24) },
                                new Track { Number = 3, Title = "Stan", Length = TimeSpan.FromMinutes(6.44) },
                                new Track { Number = 4, Title = "Paul (Skit)", Length = TimeSpan.FromMinutes(0.11) },
                                new Track { Number = 5, Title = "Who Knew", Length = TimeSpan.FromMinutes(3.48) },
                                new Track { Number = 6, Title = "Steve Berman (Skit)", Length = TimeSpan.FromMinutes(0.54) },
                                new Track { Number = 7, Title = "The Way I Am", Length = TimeSpan.FromMinutes(4.50) },
                                new Track { Number = 8, Title = "The Real Slim Shady", Length = TimeSpan.FromMinutes(4.44) },
                                new Track { Number = 9, Title = "Remember Me?", Length = TimeSpan.FromMinutes(3.38) },
                                new Track { Number = 10, Title = "I'm Back", Length = TimeSpan.FromMinutes(5.10) },
                                new Track { Number = 11, Title = "Marshall Mathers", Length = TimeSpan.FromMinutes(5.20) },
                                new Track { Number = 12, Title = "Ken Kaniff (Skit)", Length = TimeSpan.FromMinutes(1.16) },
                                new Track { Number = 13, Title = "Drug Ballad", Length = TimeSpan.FromMinutes(5.00) },
                                new Track { Number = 14, Title = "Amityville", Length = TimeSpan.FromMinutes(4.14) },
                                new Track { Number = 15, Title = "Bitch Please II", Length = TimeSpan.FromMinutes(4.48) },
                                new Track { Number = 16, Title = "Kim", Length = TimeSpan.FromMinutes(6.18) },
                                new Track { Number = 17, Title = "Under the Influence", Length = TimeSpan.FromMinutes(5.22) },
                                new Track { Number = 18, Title = "Criminal", Length = TimeSpan.FromMinutes(5.19) }
                            }
                        },
                        new CD
                        {
                            Name = "The Eminem Show",
                            Genre_ID = genreDictionary["Hip-Hop"],
                            TrackList = new List<Track>
                            {
                                new Track { Number = 1, Title = "Curtains Up (Skit)", Length = TimeSpan.FromMinutes(0.30) },
                                new Track { Number = 2, Title = "White America", Length = TimeSpan.FromMinutes(5.24) },
                                new Track { Number = 3, Title = "Business", Length = TimeSpan.FromMinutes(4.11) },
                                new Track { Number = 4, Title = "Cleanin' Out My Closet", Length = TimeSpan.FromMinutes(4.57) },
                                new Track { Number = 5, Title = "Square Dance", Length = TimeSpan.FromMinutes(5.23) },
                                new Track { Number = 6, Title = "The Kiss (Skit)", Length = TimeSpan.FromMinutes(1.15) },
                                new Track { Number = 7, Title = "Soldier", Length = TimeSpan.FromMinutes(3.46) },
                                new Track { Number = 8, Title = "Say Goodbye Hollywood", Length = TimeSpan.FromMinutes(4.32) },
                                new Track { Number = 9, Title = "Drips", Length = TimeSpan.FromMinutes(4.45) },
                                new Track { Number = 10, Title = "Without Me", Length = TimeSpan.FromMinutes(4.50) },
                                new Track { Number = 11, Title = "Paul Rosenberg (Skit)", Length = TimeSpan.FromMinutes(0.22) },
                                new Track { Number = 12, Title = "Sing for the Moment", Length = TimeSpan.FromMinutes(5.40) },
                                new Track { Number = 13, Title = "Superman", Length = TimeSpan.FromMinutes(5.50) },
                                new Track { Number = 14, Title = "Hailie's Song", Length = TimeSpan.FromMinutes(5.20) },
                                new Track { Number = 15, Title = "Steve Berman (Skit)", Length = TimeSpan.FromMinutes(0.33) },
                                new Track { Number = 16, Title = "When the Music Stops", Length = TimeSpan.FromMinutes(4.29) },
                                new Track { Number = 17, Title = "Say What You Say", Length = TimeSpan.FromMinutes(5.09) },
                                new Track { Number = 18, Title = "'Till I Collapse", Length = TimeSpan.FromMinutes(4.58) },
                                new Track { Number = 19, Title = "My Dad's Gone Crazy", Length = TimeSpan.FromMinutes(4.27) },
                                new Track { Number = 20, Title = "Curtains Close (Skit)", Length = TimeSpan.FromMinutes(1.01) }
                            }
                        }
                    }
                }
            };

            Context.Albums.AddRange(albums);
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
