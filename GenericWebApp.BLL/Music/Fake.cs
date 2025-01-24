using System;
using System.Collections.Generic;

namespace GenericWebApp.BLL.Music
{
    internal static class Fake
    {
        internal static List<DTO.Music.Album> FakeCallDB()
        {
            List<DTO.Music.Album> list = new List<DTO.Music.Album>();

            list.Add(new DTO.Music.Album()
            {
                ArtistName = "Daft Punk",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "Random Access Memories",
                        Genre = "Disco",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Give Life Back to Music",
                                Length = TimeSpan.FromMinutes(4.34)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "The Game of Love",
                                Length = TimeSpan.FromMinutes(5.22)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Giorgio By Moroder",
                                Length = TimeSpan.FromMinutes(9.04)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Within",
                                Length = TimeSpan.FromMinutes(3.48)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Instant Crush",
                                Length = TimeSpan.FromMinutes(5.37)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Lose Yourself To Dance",
                                Length = TimeSpan.FromMinutes(5.53)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Touch",
                                Length = TimeSpan.FromMinutes(8.18)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Get Lucky",
                                Length = TimeSpan.FromMinutes(6.09)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "Beyond",
                                Length = TimeSpan.FromMinutes(4.50)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Motherboard",
                                Length = TimeSpan.FromMinutes(5.41)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Fragments Of Time",
                                Length = TimeSpan.FromMinutes(4.39)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "Doin' It Right",
                                Length = TimeSpan.FromMinutes(4.11)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 13,
                                Title = "Contact",
                                Length = TimeSpan.FromMinutes(6.23)
                            }
                        }
                    }
                }
            });

            list.Add(new DTO.Music.Album()
            {
                ArtistName = "The Glitch Mob",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "Drink The Sea",
                        Genre = "Miscellaneous",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Animus Vox",
                                Length = TimeSpan.FromMinutes(6.44)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "Bad Wings",
                                Length = TimeSpan.FromMinutes(6.39)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "How to Be Eaten by a Woman",
                                Length = TimeSpan.FromMinutes(6.00)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "A Dream Within a Dream",
                                Length = TimeSpan.FromMinutes(5.24)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Fistful of Silence",
                                Length = TimeSpan.FromMinutes(6.11)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Between Two Points",
                                Length = TimeSpan.FromMinutes(4.44)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "We Swarm",
                                Length = TimeSpan.FromMinutes(5.56)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Drive It Like You Stole It",
                                Length = TimeSpan.FromMinutes(5.55)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "Fortune Days",
                                Length = TimeSpan.FromMinutes(6.23)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Starve the Ego, Feed the Soul",
                                Length = TimeSpan.FromMinutes(5.52)
                            }
                        }
                    }
                }
            });

            list.Add(new DTO.Music.Album()
            {
                ArtistName = "Soundgarden",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "Louder Than Love",
                        Label = "A&M",
                        Genre = "Grunge",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Ugly Truth",
                                Length = TimeSpan.FromMinutes(5.26)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "Hands All Over",
                                Length = TimeSpan.FromMinutes(6.00)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Gun",
                                Length = TimeSpan.FromMinutes(4.42)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Power Trip",
                                Length = TimeSpan.FromMinutes(4.10)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Get on the Snake",
                                Length = TimeSpan.FromMinutes(3.44)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Full on Kevin's Mom",
                                Length = TimeSpan.FromMinutes(3.37)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Loud Love",
                                Length = TimeSpan.FromMinutes(4.57)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "I Awake",
                                Length = TimeSpan.FromMinutes(4.21)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "No Wrong No Right",
                                Length = TimeSpan.FromMinutes(4.47)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Uncovered",
                                Length = TimeSpan.FromMinutes(4.30)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Big Dumb Sex",
                                Length = TimeSpan.FromMinutes(4.11)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "Full on (Reprise)",
                                Length = TimeSpan.FromMinutes(2.42)
                            }
                        }
                    },
                    new DTO.Music.CD()
                    {
                        Name = "Badmotorfinger",
                        Label = "A&M",
                        Genre = "Grunge",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Rusty Cage",
                                Length = TimeSpan.FromMinutes(4.26)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "Outshined",
                                Length = TimeSpan.FromMinutes(5.11)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Slaves & Bulldozers",
                                Length = TimeSpan.FromMinutes(6.56)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Jesus Christ Pose",
                                Length = TimeSpan.FromMinutes(5.51)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Face Pollution",
                                Length = TimeSpan.FromMinutes(2.24)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Somewhere",
                                Length = TimeSpan.FromMinutes(4.21)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Searching with My Good Eye Closed",
                                Length = TimeSpan.FromMinutes(6.31)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Room a Thousand Years Wide",
                                Length = TimeSpan.FromMinutes(4.06)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "Mind Riot",
                                Length = TimeSpan.FromMinutes(4.49)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "Mind Riot",
                                Length = TimeSpan.FromMinutes(4.49)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Drawing Flies",
                                Length = TimeSpan.FromMinutes(2.25)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Holy Water",
                                Length = TimeSpan.FromMinutes(5.07)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "New Damage",
                                Length = TimeSpan.FromMinutes(5.40)
                            }
                        }
                    }
                }
            });

            // New Artist 1
            list.Add(new DTO.Music.Album()
            {
                ArtistName = "Radiohead",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "OK Computer",
                        Genre = "Alternative Rock",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Airbag",
                                Length = TimeSpan.FromMinutes(4.44)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "Paranoid Android",
                                Length = TimeSpan.FromMinutes(6.23)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Subterranean Homesick Alien",
                                Length = TimeSpan.FromMinutes(4.27)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Exit Music (For a Film)",
                                Length = TimeSpan.FromMinutes(4.24)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Let Down",
                                Length = TimeSpan.FromMinutes(4.59)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Karma Police",
                                Length = TimeSpan.FromMinutes(4.21)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Fitter Happier",
                                Length = TimeSpan.FromMinutes(1.57)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Electioneering",
                                Length = TimeSpan.FromMinutes(3.50)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "Climbing Up the Walls",
                                Length = TimeSpan.FromMinutes(4.45)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "No Surprises",
                                Length = TimeSpan.FromMinutes(3.48)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Lucky",
                                Length = TimeSpan.FromMinutes(4.19)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "The Tourist",
                                Length = TimeSpan.FromMinutes(5.24)
                            }
                        }
                    }
                }
            });

            // New Artist 2
            list.Add(new DTO.Music.Album()
            {
                ArtistName = "Nirvana",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "Nevermind",
                        Genre = "Grunge",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Smells Like Teen Spirit",
                                Length = TimeSpan.FromMinutes(5.01)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "In Bloom",
                                Length = TimeSpan.FromMinutes(4.14)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Come as You Are",
                                Length = TimeSpan.FromMinutes(3.39)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Breed",
                                Length = TimeSpan.FromMinutes(3.03)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Lithium",
                                Length = TimeSpan.FromMinutes(4.17)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Polly",
                                Length = TimeSpan.FromMinutes(2.57)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Territorial Pissings",
                                Length = TimeSpan.FromMinutes(2.22)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Drain You",
                                Length = TimeSpan.FromMinutes(3.43)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "Lounge Act",
                                Length = TimeSpan.FromMinutes(2.36)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Stay Away",
                                Length = TimeSpan.FromMinutes(3.32)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "On a Plain",
                                Length = TimeSpan.FromMinutes(3.16)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "Something in the Way",
                                Length = TimeSpan.FromMinutes(3.52)
                            }
                        }
                    }
                }
            });

            // New Artist 3
            list.Add(new DTO.Music.Album()
            {
                ArtistName = "The Beatles",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "Abbey Road",
                        Genre = "Rock",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Come Together",
                                Length = TimeSpan.FromMinutes(4.20)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "Something",
                                Length = TimeSpan.FromMinutes(3.03)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Maxwell's Silver Hammer",
                                Length = TimeSpan.FromMinutes(3.27)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Oh! Darling",
                                Length = TimeSpan.FromMinutes(3.26)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Octopus's Garden",
                                Length = TimeSpan.FromMinutes(2.51)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "I Want You (She's So Heavy)",
                                Length = TimeSpan.FromMinutes(7.47)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Here Comes the Sun",
                                Length = TimeSpan.FromMinutes(3.05)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Because",
                                Length = TimeSpan.FromMinutes(2.45)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "You Never Give Me Your Money",
                                Length = TimeSpan.FromMinutes(4.02)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Sun King",
                                Length = TimeSpan.FromMinutes(2.26)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Mean Mr. Mustard",
                                Length = TimeSpan.FromMinutes(1.06)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "Polythene Pam",
                                Length = TimeSpan.FromMinutes(1.12)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 13,
                                Title = "She Came in Through the Bathroom Window",
                                Length = TimeSpan.FromMinutes(1.57)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 14,
                                Title = "Golden Slumbers",
                                Length = TimeSpan.FromMinutes(1.31)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 15,
                                Title = "Carry That Weight",
                                Length = TimeSpan.FromMinutes(1.36)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 16,
                                Title = "The End",
                                Length = TimeSpan.FromMinutes(2.20)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 17,
                                Title = "Her Majesty",
                                Length = TimeSpan.FromMinutes(0.23)
                            }
                        }
                    }
                }
            });

            // Rap Artist 1
            list.Add(new DTO.Music.Album()
            {
                ArtistName = "Kendrick Lamar",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "DAMN.",
                        Genre = "Hip Hop",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "DNA.",
                                Length = TimeSpan.FromMinutes(3.05)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "YAH.",
                                Length = TimeSpan.FromMinutes(2.40)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "ELEMENT.",
                                Length = TimeSpan.FromMinutes(3.28)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "FEEL.",
                                Length = TimeSpan.FromMinutes(3.34)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "LOYALTY. (feat. Rihanna)",
                                Length = TimeSpan.FromMinutes(3.47)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "PRIDE.",
                                Length = TimeSpan.FromMinutes(4.35)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "HUMBLE.",
                                Length = TimeSpan.FromMinutes(2.57)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "LUST.",
                                Length = TimeSpan.FromMinutes(5.08)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "LOVE. (feat. Zacari)",
                                Length = TimeSpan.FromMinutes(3.33)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "XXX. (feat. U2)",
                                Length = TimeSpan.FromMinutes(4.14)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "FEAR.",
                                Length = TimeSpan.FromMinutes(7.40)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "GOD.",
                                Length = TimeSpan.FromMinutes(4.08)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 13,
                                Title = "DUCKWORTH.",
                                Length = TimeSpan.FromMinutes(4.08)
                            }
                        }
                    }
                }
            });

            // Rap Artist 2
            list.Add(new DTO.Music.Album()
            {
                ArtistName = "J. Cole",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "2014 Forest Hills Drive",
                        Genre = "Hip Hop",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Intro",
                                Length = TimeSpan.FromMinutes(2.09)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "January 28th",
                                Length = TimeSpan.FromMinutes(4.02)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Wet Dreamz",
                                Length = TimeSpan.FromMinutes(3.59)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "03' Adolescence",
                                Length = TimeSpan.FromMinutes(3.16)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "A Tale of 2 Citiez",
                                Length = TimeSpan.FromMinutes(4.29)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Fire Squad",
                                Length = TimeSpan.FromMinutes(4.48)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "St. Tropez",
                                Length = TimeSpan.FromMinutes(4.17)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "G.O.M.D.",
                                Length = TimeSpan.FromMinutes(5.01)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "No Role Modelz",
                                Length = TimeSpan.FromMinutes(4.52)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Hello",
                                Length = TimeSpan.FromMinutes(3.39)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Apparently",
                                Length = TimeSpan.FromMinutes(4.53)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "Love Yourz",
                                Length = TimeSpan.FromMinutes(3.31)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 13,
                                Title = "Note to Self",
                                Length = TimeSpan.FromMinutes(14.35)
                            }
                        }
                    }
                }
            });

            // Rap Artist 3
            list.Add(new DTO.Music.Album()
            {
                ArtistName = "Drake",
                CDList = new List<DTO.Music.CD>()
                {
                    new DTO.Music.CD()
                    {
                        Name = "Take Care",
                        Genre = "Hip Hop",
                        TrackList = new List<DTO.Music.Track>()
                        {
                            new DTO.Music.Track()
                            {
                                Number = 1,
                                Title = "Over My Dead Body",
                                Length = TimeSpan.FromMinutes(4.32)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 2,
                                Title = "Shot for Me",
                                Length = TimeSpan.FromMinutes(3.45)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 3,
                                Title = "Headlines",
                                Length = TimeSpan.FromMinutes(3.56)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 4,
                                Title = "Crew Love (feat. The Weeknd)",
                                Length = TimeSpan.FromMinutes(3.29)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 5,
                                Title = "Take Care (feat. Rihanna)",
                                Length = TimeSpan.FromMinutes(4.37)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 6,
                                Title = "Marvins Room",
                                Length = TimeSpan.FromMinutes(5.47)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 7,
                                Title = "Buried Alive Interlude (feat. Kendrick Lamar)",
                                Length = TimeSpan.FromMinutes(2.31)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 8,
                                Title = "Under Ground Kings",
                                Length = TimeSpan.FromMinutes(3.32)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 9,
                                Title = "We'll Be Fine (feat. Birdman)",
                                Length = TimeSpan.FromMinutes(4.08)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 10,
                                Title = "Make Me Proud (feat. Nicki Minaj)",
                                Length = TimeSpan.FromMinutes(3.39)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 11,
                                Title = "Lord Knows (feat. Rick Ross)",
                                Length = TimeSpan.FromMinutes(5.08)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 12,
                                Title = "Cameras / Good Ones Go Interlude",
                                Length = TimeSpan.FromMinutes(7.14)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 13,
                                Title = "Doing It Wrong",
                                Length = TimeSpan.FromMinutes(4.25)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 14,
                                Title = "The Real Her (feat. Lil Wayne & Andre 3000)",
                                Length = TimeSpan.FromMinutes(5.21)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 15,
                                Title = "Look What You've Done",
                                Length = TimeSpan.FromMinutes(5.02)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 16,
                                Title = "HYFR (Hell Ya Fucking Right) (feat. Lil Wayne)",
                                Length = TimeSpan.FromMinutes(3.27)
                            },
                            new DTO.Music.Track()
                            {
                                Number = 17,
                                Title = "Practice",
                                Length = TimeSpan.FromMinutes(3.57)
                            },
                            new DTO.Music.Track()
                                {
                                    Number = 18,
                                    Title = "The Ride",
                                    Length = TimeSpan.FromMinutes(5.51)
                                }
                            }
                        }
                    }
            });

            return list;
        }
    }
}
