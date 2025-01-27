using System;
using System.Collections.Generic;
using System.Linq;
using GenericWebApp.Model.Music;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            //SeedTestData_MusicGenre();
            //SeedTestData_MusicAlbums();
        }

        public static void SeedTestData_MusicGenre()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
                    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GenericWebApp;Trusted_Connection=True;")
                    .Options;

            using var context = new AlbumContext(options);
            // Ensure the database is created
            context.Database.EnsureCreated();

            // Create and add genres
            var genres = new List<Genre>
            {
                new() { Description = "Rock" },
                new() { Description = "Pop" },
                new() { Description = "Jazz" },
                new() { Description = "Classical" },
                new() { Description = "Hip-Hop" },
                new() { Description = "Electronic" },
                new() { Description = "Country" },
                new() { Description = "Reggae" },
                new() { Description = "Blues" },
                new() { Description = "Metal" }
            };

            context.Genres.AddRange(genres);
            context.SaveChanges();
        }

        public static void SeedTestData_MusicAlbums()
        {
            var options = new DbContextOptionsBuilder<AlbumContext>()
                    .UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GenericWebApp;Trusted_Connection=True;")
                    .Options;

            using (var context = new AlbumContext(options))
            {
                // Ensure the database is created
                context.Database.EnsureCreated();

                // Retrieve the genre IDs from the database
                var genreDictionary = context.Genres.ToDictionary(g => g.Description, g => g.ID);

                // Create and add albums, CDs, and tracks
                var albums = new List<Album>
                {
                    new() {
                        ArtistName = "The Beatles",
                        CDList =
                        [
                            new CD
                            {
                                Name = "Abbey Road",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
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
                                ]
                            },
                            new CD
                            {
                                Name = "Sgt. Pepper's Lonely Hearts Club Band",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
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
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Daft Punk",
                        CDList =
                        [
                            new CD
                            {
                                Name = "Random Access Memories",
                                Genre_ID = genreDictionary["Electronic"],
                                TrackList =
                                [
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
                                ]
                            },
                            new CD
                            {
                                Name = "Discovery",
                                Genre_ID = genreDictionary["Electronic"],
                                TrackList =
                                [
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
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Beyoncé",
                        CDList =
                        [
                            new CD
                            {
                                Name = "Lemonade",
                                Genre_ID = genreDictionary["Pop"],
                                TrackList =
                                [
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
                                ]
                            },
                            new CD
                            {
                                Name = "Beyoncé",
                                Genre_ID = genreDictionary["Pop"],
                                TrackList =
                                [
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
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Eminem",
                        CDList =
                        [
                            new CD
                            {
                                Name = "The Marshall Mathers LP",
                                Genre_ID = genreDictionary["Hip-Hop"],
                                TrackList =
                                [
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
                                ]
                            },
                            new CD
                            {
                                Name = "The Eminem Show",
                                Genre_ID = genreDictionary["Hip-Hop"],
                                TrackList =
                                [
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
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Miles Davis",
                        CDList =
                        [
                            new CD
                            {
                                Name = "Kind of Blue",
                                Genre_ID = genreDictionary["Jazz"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "So What", Length = TimeSpan.FromMinutes(9.22) },
                                    new Track { Number = 2, Title = "Freddie Freeloader", Length = TimeSpan.FromMinutes(9.46) },
                                    new Track { Number = 3, Title = "Blue in Green", Length = TimeSpan.FromMinutes(5.37) },
                                    new Track { Number = 4, Title = "All Blues", Length = TimeSpan.FromMinutes(11.33) },
                                    new Track { Number = 5, Title = "Flamenco Sketches", Length = TimeSpan.FromMinutes(9.25) }
                                ]
                            },
                            new CD
                            {
                                Name = "Bitches Brew",
                                Genre_ID = genreDictionary["Jazz"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Pharaoh's Dance", Length = TimeSpan.FromMinutes(20.00) },
                                    new Track { Number = 2, Title = "Bitches Brew", Length = TimeSpan.FromMinutes(27.00) },
                                    new Track { Number = 3, Title = "Spanish Key", Length = TimeSpan.FromMinutes(17.00) },
                                    new Track { Number = 4, Title = "John McLaughlin", Length = TimeSpan.FromMinutes(4.00) },
                                    new Track { Number = 5, Title = "Miles Runs the Voodoo Down", Length = TimeSpan.FromMinutes(14.00) },
                                    new Track { Number = 6, Title = "Sanctuary", Length = TimeSpan.FromMinutes(11.00) }
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Pink Floyd",
                        CDList =
                        [
                            new CD
                            {
                                Name = "The Dark Side of the Moon",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Speak to Me", Length = TimeSpan.FromMinutes(1.30) },
                                    new Track { Number = 2, Title = "Breathe", Length = TimeSpan.FromMinutes(2.43) },
                                    new Track { Number = 3, Title = "On the Run", Length = TimeSpan.FromMinutes(3.30) },
                                    new Track { Number = 4, Title = "Time", Length = TimeSpan.FromMinutes(6.53) },
                                    new Track { Number = 5, Title = "The Great Gig in the Sky", Length = TimeSpan.FromMinutes(4.15) },
                                    new Track { Number = 6, Title = "Money", Length = TimeSpan.FromMinutes(6.22) },
                                    new Track { Number = 7, Title = "Us and Them", Length = TimeSpan.FromMinutes(7.48) },
                                    new Track { Number = 8, Title = "Any Colour You Like", Length = TimeSpan.FromMinutes(3.25) },
                                    new Track { Number = 9, Title = "Brain Damage", Length = TimeSpan.FromMinutes(3.50) },
                                    new Track { Number = 10, Title = "Eclipse", Length = TimeSpan.FromMinutes(2.06) }
                                ]
                            },
                            new CD
                            {
                                Name = "Wish You Were Here",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Shine On You Crazy Diamond (Parts I-V)", Length = TimeSpan.FromMinutes(13.32) },
                                    new Track { Number = 2, Title = "Welcome to the Machine", Length = TimeSpan.FromMinutes(7.31) },
                                    new Track { Number = 3, Title = "Have a Cigar", Length = TimeSpan.FromMinutes(5.08) },
                                    new Track { Number = 4, Title = "Wish You Were Here", Length = TimeSpan.FromMinutes(5.34) },
                                    new Track { Number = 5, Title = "Shine On You Crazy Diamond (Parts VI-IX)", Length = TimeSpan.FromMinutes(12.29) }
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Led Zeppelin",
                        CDList =
                        [
                            new CD
                            {
                                Name = "Led Zeppelin IV",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Black Dog", Length = TimeSpan.FromMinutes(4.55) },
                                    new Track { Number = 2, Title = "Rock and Roll", Length = TimeSpan.FromMinutes(3.40) },
                                    new Track { Number = 3, Title = "The Battle of Evermore", Length = TimeSpan.FromMinutes(5.52) },
                                    new Track { Number = 4, Title = "Stairway to Heaven", Length = TimeSpan.FromMinutes(8.02) },
                                    new Track { Number = 5, Title = "Misty Mountain Hop", Length = TimeSpan.FromMinutes(4.38) },
                                    new Track { Number = 6, Title = "Four Sticks", Length = TimeSpan.FromMinutes(4.45) },
                                    new Track { Number = 7, Title = "Going to California", Length = TimeSpan.FromMinutes(3.31) },
                                    new Track { Number = 8, Title = "When the Levee Breaks", Length = TimeSpan.FromMinutes(7.08) }
                                ]
                            },
                            new CD
                            {
                                Name = "Physical Graffiti",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Custard Pie", Length = TimeSpan.FromMinutes(4.13) },
                                    new Track { Number = 2, Title = "The Rover", Length = TimeSpan.FromMinutes(5.36) },
                                    new Track { Number = 3, Title = "In My Time of Dying", Length = TimeSpan.FromMinutes(11.04) },
                                    new Track { Number = 4, Title = "Houses of the Holy", Length = TimeSpan.FromMinutes(4.02) },
                                    new Track { Number = 5, Title = "Trampled Under Foot", Length = TimeSpan.FromMinutes(5.35) },
                                    new Track { Number = 6, Title = "Kashmir", Length = TimeSpan.FromMinutes(8.37) },
                                    new Track { Number = 7, Title = "In the Light", Length = TimeSpan.FromMinutes(8.46) },
                                    new Track { Number = 8, Title = "Bron-Yr-Aur", Length = TimeSpan.FromMinutes(2.06) },
                                    new Track { Number = 9, Title = "Down by the Seaside", Length = TimeSpan.FromMinutes(5.14) },
                                    new Track { Number = 10, Title = "Ten Years Gone", Length = TimeSpan.FromMinutes(6.31) },
                                    new Track { Number = 11, Title = "Night Flight", Length = TimeSpan.FromMinutes(3.37) },
                                    new Track { Number = 12, Title = "The Wanton Song", Length = TimeSpan.FromMinutes(4.06) },
                                    new Track { Number = 13, Title = "Boogie with Stu", Length = TimeSpan.FromMinutes(3.53) },
                                    new Track { Number = 14, Title = "Black Country Woman", Length = TimeSpan.FromMinutes(4.24) },
                                    new Track { Number = 15, Title = "Sick Again", Length = TimeSpan.FromMinutes(4.43) }
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Michael Jackson",
                        CDList =
                        [
                            new CD
                            {
                                Name = "Thriller",
                                Genre_ID = genreDictionary["Pop"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Wanna Be Startin' Somethin'", Length = TimeSpan.FromMinutes(6.03) },
                                    new Track { Number = 2, Title = "Baby Be Mine", Length = TimeSpan.FromMinutes(4.20) },
                                    new Track { Number = 3, Title = "The Girl Is Mine", Length = TimeSpan.FromMinutes(3.42) },
                                    new Track { Number = 4, Title = "Thriller", Length = TimeSpan.FromMinutes(5.57) },
                                    new Track { Number = 5, Title = "Beat It", Length = TimeSpan.FromMinutes(4.18) },
                                    new Track { Number = 6, Title = "Billie Jean", Length = TimeSpan.FromMinutes(4.54) },
                                    new Track { Number = 7, Title = "Human Nature", Length = TimeSpan.FromMinutes(4.06) },
                                    new Track { Number = 8, Title = "P.Y.T. (Pretty Young Thing)", Length = TimeSpan.FromMinutes(3.59) },
                                    new Track { Number = 9, Title = "The Lady in My Life", Length = TimeSpan.FromMinutes(4.59) }
                                ]
                            },
                            new CD
                            {
                                Name = "Bad",
                                Genre_ID = genreDictionary["Pop"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Bad", Length = TimeSpan.FromMinutes(4.07) },
                                    new Track { Number = 2, Title = "The Way You Make Me Feel", Length = TimeSpan.FromMinutes(4.58) },
                                    new Track { Number = 3, Title = "Speed Demon", Length = TimeSpan.FromMinutes(4.01) },
                                    new Track { Number = 4, Title = "Liberian Girl", Length = TimeSpan.FromMinutes(3.52) },
                                    new Track { Number = 5, Title = "Just Good Friends", Length = TimeSpan.FromMinutes(4.06) },
                                    new Track { Number = 6, Title = "Another Part of Me", Length = TimeSpan.FromMinutes(3.54) },
                                    new Track { Number = 7, Title = "Man in the Mirror", Length = TimeSpan.FromMinutes(5.19) },
                                    new Track { Number = 8, Title = "I Just Can't Stop Loving You", Length = TimeSpan.FromMinutes(4.12) },
                                    new Track { Number = 9, Title = "Dirty Diana", Length = TimeSpan.FromMinutes(4.41) },
                                    new Track { Number = 10, Title = "Smooth Criminal", Length = TimeSpan.FromMinutes(4.17) }
                                ]
                            }
                        ]
                    },
                    new() {
                        ArtistName = "Queen",
                        CDList =
                        [
                            new CD
                            {
                                Name = "A Night at the Opera",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Death on Two Legs (Dedicated to...)", Length = TimeSpan.FromMinutes(3.43) },
                                    new Track { Number = 2, Title = "Lazing on a Sunday Afternoon", Length = TimeSpan.FromMinutes(1.08) },
                                    new Track { Number = 3, Title = "I'm in Love with My Car", Length = TimeSpan.FromMinutes(3.05) },
                                    new Track { Number = 4, Title = "You're My Best Friend", Length = TimeSpan.FromMinutes(2.50) },
                                    new Track { Number = 5, Title = "'39", Length = TimeSpan.FromMinutes(3.30) },
                                    new Track { Number = 6, Title = "Sweet Lady", Length = TimeSpan.FromMinutes(4.03) },
                                    new Track { Number = 7, Title = "Seaside Rendezvous", Length = TimeSpan.FromMinutes(2.13) },
                                    new Track { Number = 8, Title = "The Prophet's Song", Length = TimeSpan.FromMinutes(8.21) },
                                    new Track { Number = 9, Title = "Love of My Life", Length = TimeSpan.FromMinutes(3.38) },
                                    new Track { Number = 10, Title = "Good Company", Length = TimeSpan.FromMinutes(3.23) },
                                    new Track { Number = 11, Title = "Bohemian Rhapsody", Length = TimeSpan.FromMinutes(5.55) },
                                    new Track { Number = 12, Title = "God Save the Queen", Length = TimeSpan.FromMinutes(1.11) }
                                ]
                            },
                            new CD
                            {
                                Name = "The Game",
                                Genre_ID = genreDictionary["Rock"],
                                TrackList =
                                [
                                    new Track { Number = 1, Title = "Play the Game", Length = TimeSpan.FromMinutes(3.30) },
                                    new Track { Number = 2, Title = "Dragon Attack", Length = TimeSpan.FromMinutes(4.18) },
                                    new Track { Number = 3, Title = "Another One Bites the Dust", Length = TimeSpan.FromMinutes(3.35) },
                                    new Track { Number = 4, Title = "Need Your Loving Tonight", Length = TimeSpan.FromMinutes(2.50) },
                                    new Track { Number = 5, Title = "Crazy Little Thing Called Love", Length = TimeSpan.FromMinutes(2.44) },
                                    new Track { Number = 6, Title = "Rock It (Prime Jive)", Length = TimeSpan.FromMinutes(4.33) },
                                    new Track { Number = 7, Title = "Don't Try Suicide", Length = TimeSpan.FromMinutes(3.52) },
                                    new Track { Number = 8, Title = "Sail Away Sweet Sister", Length = TimeSpan.FromMinutes(3.33) },
                                    new Track { Number = 9, Title = "Coming Soon", Length = TimeSpan.FromMinutes(2.50) },
                                    new Track { Number = 10, Title = "Save Me", Length = TimeSpan.FromMinutes(3.48) }
                                ]
                            }
                        ]
                    }
                };

                context.Albums.AddRange(albums);
                context.SaveChanges();
            }

            Console.WriteLine("Data populated successfully!");
        }
    }
}
