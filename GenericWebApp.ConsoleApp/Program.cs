using System;
using System.Collections.Generic;
using System.Linq;
using GenericWebApp.Model.Music;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        if (false)
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
                .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GenericWebApp;Trusted_Connection=True;")
                .Options;

            using (var context = new AlbumContext(options))
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

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

                context.Genres.AddRange(genres);
                context.SaveChanges();

                // Retrieve the genre IDs from the database
                var genreDictionary = context.Genres.ToDictionary(g => g.Description, g => g.ID);

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
                                Genre_ID = genres.FirstOrDefault(g => g.Description == "Rock").ID,
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
                                Genre_ID = genres.FirstOrDefault(g => g.Description == "Rock").ID,
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
                } };

                context.Albums.AddRange(albums);
                context.SaveChanges();
            }

            Console.WriteLine("Data populated successfully!");
        }
    }
}
