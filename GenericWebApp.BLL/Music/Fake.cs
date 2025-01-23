using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Music
{
    internal static class Fake
    {
        internal static List<DTO.Music.Album> FakeCallDB()
        {
            List<DTO.Music.Album> list = new List<DTO.Music.Album>();

            list.Add(new DTO.Music.Album()
            {
                #region -- Daft Punk --
                ArtistName = "Daft Punk",
                CDList = new List<DTO.Music.CD>()
                {
                        #region - Random Access Memories -
                        new DTO.Music.CD()
                        {
                            Name = "Random Access Memories",
                            Genere = "Disco",
                            TrackList = new List<DTO.Music.Track>()
                            {
                                new DTO.Music.Track()
                                {
                                    Number = 2,
                                    Title = "The Game of Love",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(5.22))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 3,
                                    Title = "Giorgio By Moroder",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(9.04))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 4,
                                    Title = "Within",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(3.48))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 5,
                                    Title = "Instant Crush",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(5.37))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 6,
                                    Title = "Lose Yourself To Dance",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(5.53))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 7,
                                    Title = "Touch",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(8.18))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 8,
                                    Title = "Get Lucky",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(6.09))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 9,
                                    Title = "Beyond",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(4.50))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 10,
                                    Title = "Motherboard",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(5.41))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 11,
                                    Title = "Fragments Of Time",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(4.39))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 12,
                                    Title = "Doin' It Right",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(4.11))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 13,
                                    Title = "Contact",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(6.23))
                                }
                            }
                        }
                        #endregion
                }
                #endregion
            });

            list.Add(new DTO.Music.Album()
            {
                #region -- The Glitch Mob --
                ArtistName = "The Glitch Mob",
                CDList = new List<DTO.Music.CD>()
                {
                        #region - Drink The Sea -
                        new DTO.Music.CD()
                        {
                            Name = "Drink The Sea",
                            Genere = "Miscellaneous",
                            TrackList = new List<DTO.Music.Track>()
                            {
                                new DTO.Music.Track()
                                {
                                    Number = 1,
                                    Title = "Animus Vox",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(6.44))
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 2,
                                    Title = "Bad Wings",
                                    Length = TimeOnly.FromTimeSpan(TimeSpan.FromMinutes(6.39))
                                }
                            }
                        }
                        #endregion
                }
                #endregion
            });

			//Grabbed the list from: https://en.wikipedia.org/wiki/List_of_grunge_albums
			//Formatted in Google Sheet
			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Soundgarden",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Louder Than Love", Label = "A&M",
						Genere = "Grunge"
					},
					new DTO.Music.CD()
					{
						Name = "Badmotorfinger", Label = "A&M",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Temple of the Dog",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Temple of the Dog", Label = "A&M",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hammerbox",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Numb", Label = "A&M",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hater",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Hater", Label = "A&M",
						Genere = "Grunge"
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
						Name = "Superunknown", Label = "A&M",
						Genere = "Grunge"
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
						Name = "Songs from the Superunknown", Label = "A&M",
						Genere = "Grunge"
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
						Name = "Down on the Upside", Label = "A&M",
						Genere = "Grunge"
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
						Name = "A-Sides", Label = "A&M",
						Genere = "Grunge"
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
						Name = "Telephantasm", Label = "A&M Records",
						Genere = "Grunge"
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
						Name = "Live on I-5", Label = "A&M Records",
						Genere = "Grunge"
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
						Name = "Echo of Miles: Scattered Tracks Across the Path", Label = "A&M Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Gluey Porch Treatments", Label = "Alchemy",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Babes in Toyland",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Lived, Devil, Viled", Label = "Almafame",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Core", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Houdini", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Stoner Witch", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Purple", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "7 Year Bitch",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Gato Negro", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Stag", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Tiny Music... Songs from the Vatican Gift Shop", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Honky", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "No. 4", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Shangri-La Dee Da", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Thank You", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Stone Temple Pilots",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Stone Temple Pilots", Label = "Atlantic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live at Benaroya Hall", Label = "BMG",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Rainier Fog", Label = "BMG",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Kingdom", Label = "BMG",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Ozma", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Bullhead", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Eggnog", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "King Buzzo", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Dale Crover", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Joe Preston", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Lysol", Label = "Boner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Slap-Happy", Label = "Bong Load Custom",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Deep Six", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Melvins", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Skin Yard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Skin Yard", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various Artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Another Pyrrhic Victory", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hammerbox",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Hammerbox", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "7 Year Bitch",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Sick 'Em", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "7 Year Bitch",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "¡Viva Zapata!", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Love Battery",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Confusion Au Go Go", Label = "C/Z Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Truly",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Fast Stories... from Kid Coma", Label = "Capitol",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Truly",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Feeling You Up", Label = "Capitol",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Truly",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Twilight Curtains", Label = "Capitol",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Devil Put Dinosaurs Here", Label = "Capitol",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Foo Fighters",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Foo Fighters", Label = "Capitol/Roswell Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Pretty on the Inside", Label = "Caroline",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Ask for It", Label = "Caroline",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "My Body, the Hand Grenade", Label = "City Slang",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "We Die Young", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Facelift", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Sap", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Dirt", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Manic Street Preachers",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Gold Against the Soul", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Jar of Flies", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Alice in Chains", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mad Season",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Above", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Unplugged", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "The Presidents of the United States of America",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "II", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Jerry Cantrell",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Boggy Depot", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "The Presidents of the United States of America",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Pure Frosting", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Nothing Safe: Best of the Box", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Music Bank", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Greatest Hits", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Essential Alice in Chains", Label = "Columbia",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Skin Yard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Fist Sized Chunks", Label = "Cruz",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Skin Yard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "1000 Smiling Knuckles", Label = "Cruz",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Skin Yard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Inside the Eye", Label = "Cruz",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Nevermind", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Incesticide", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "In Utero", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live Through This", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "MTV Unplugged in New York", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "From the Muddy Banks of the Wishkah", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Nirvana", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "With the Lights Out", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Sliver: The Best of the Box", Label = "DGC",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Tad",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Infrared Riding Hood", Label = "East West/Elektra",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mötley Crüe",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Mötley Crüe", Label = "Elektra",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Radiohead",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Pablo Honey", Label = "EMI",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Moist",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Silver", Label = "EMI",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Moist",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Creature", Label = "EMI",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Moist",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Machine Punch Through: The Singles Collection", Label = "EMI",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Alice in Chains",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Black Gives Way To Blue", Label = "EMI",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Gruntruck",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Inside Yours", Label = "eMpTy",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Something About Today", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Ten", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Uncle Anesthesia", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Sweet Oblivion", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Singles: Original Motion Picture Soundtrack", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Vs.", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Vitalogy", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Merkin Ball", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "No Code", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Dust", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Yield", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live on Two Legs", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Binaural", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Nearly Lost You", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Riot Act", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Lost Dogs", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Rearviewmirror (Greatest Hits 1991–2003)", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Ocean of Confusion: Songs of Screaming Trees 1989–1996", Label = "Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Tad",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live Alien Broadcasts", Label = "Futurist",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Celebrity Skin", Label = "Geffen",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live At Reading", Label = "Geffen",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Green River",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Come On Down", Label = "Homestead",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Maggot", Label = "Ipecac",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Bootlicker", Label = "Ipecac",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Melvins",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Crybaby", Label = "Ipecac",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Pearl Jam", Label = "J",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Zen X Four", Label = "Kirtland",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hammerbox",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live EMP Skychurch, Seattle, WA", Label = "Kufala",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "", Label = "",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Malfunkshun",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Return to Olympus", Label = "Loosegroove",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live: Omaha to Osaka", Label = "Man's Ruin",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mother Love Bone",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Shine", Label = "Mercury",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mother Love Bone",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Apple", Label = "Mercury",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mother Love Bone",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Mother Love Bone", Label = "Mercury",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Def Leppard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Slang", Label = "Mercury",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Kiss",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Carnival of Souls: The Final Sessions", Label = "Mercury",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Nobody's Daughter", Label = "Mercury",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Lightning Bolt", Label = "Monkeywrench Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Ammonia",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Mint 400", Label = "Murmur",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Silverchair",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Freak Show", Label = "Murmur",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Ammonia",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Eleventh Avenue", Label = "Murmur",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Silverchair",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Frogstomp", Label = "Murmur/Epic",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Solomon Grundy",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Solomon Grundy", Label = "New Alliance Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "The Presidents of the United States of America",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Presidents of the United States of America", Label = "PopLlama",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "The Presidents of the United States of America",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Kudos to You!", Label = "PUSA Inc.",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Babes in Toyland",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Fontanelle", Label = "Reprise",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Piece of Cake", Label = "Reprise",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Five Dollar Bob's Mock Cooter Stew", Label = "Reprise",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Babes in Toyland",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Nemesisters", Label = "Reprise",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "My Brother the Cow", Label = "Reprise",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Tomorrow Hit Today", Label = "Reprise",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Pearl Jam",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Live at the Gorge 05/06", Label = "Rhino/WEA",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Willard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Steel Mill", Label = "Roadracer Records/Roadrunner Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Gruntruck",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Push", Label = "Roadrunner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Jerry Cantrell",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Degradation Trip", Label = "Roadrunner",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Full upon Her Burning Lips", Label = "Sargent House",
						Genere = "Grunge"
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
						Name = "King Animal", Label = "Seven Four Entertainment/Republic Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Late!",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Pocketwatch", Label = "Simple Machines",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Bricks Are Heavy", Label = "Slash",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Hungry for Stink", Label = "Slash",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Beauty Process: Triple Platinum", Label = "Slash",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Slash Years", Label = "Slash",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "The Presidents of the United States of America",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Rarities", Label = "Sony Music Japan",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Hex; Or Printing in the Infernal Method", Label = "Southern Lord Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Bees Made Honey in the Lion's Skull", Label = "Southern Lord Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Angels of Darkness, Demons of Light I", Label = "Southern Lord Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Angels of Darkness, Demons of Light II", Label = "Southern Lord Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Primitive and Deadly", Label = "Southern Lord Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Best of '94–'99", Label = "SPV GmbH",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Even If and Especially When", Label = "SST",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Invisible Lantern", Label = "SST",
						Genere = "Grunge"
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
						Name = "Ultramega OK", Label = "SST",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Buzz Factory", Label = "SST",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Anthology: SST Years 1985–1989", Label = "SST",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Green River",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Dry As a Bone", Label = "Sub Pop",
						Genere = "Grunge"
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
						Name = "Screaming Life", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Green River",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Rehab Doll", Label = "Sub Pop",
						Genere = "Grunge"
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
						Name = "Fopp", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Superfuzz Bigmuff", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Sub Pop 200", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Blood Circus",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Primal Rock Therapy", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Tad",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "God's Balls", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Nirvana",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Bleach", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Mudhoney", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Green River",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Dry As a Bone/Rehab Doll", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "L7",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Smell the Magic", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Superfuzz Bigmuff Plus Early Singles", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Change Has Come", Label = "Sub Pop",
						Genere = "Grunge"
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
						Name = "Screaming Life/Fopp", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Tad",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Salt Lick/God's Balls", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Every Good Boy Deserves Fudge", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Tad",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "8-Way Santa", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various Artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Grunge Years", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Extra-Capsular Extraction", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Love Battery",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Between the Eyes", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Love Battery",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Dayglo", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Earth 2", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Phase 3: Thrones and Dominions", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Earth",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Pentastar: In the Style of Demons", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Hype!", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "March to Fuzz", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Here Comes Sickness: The Best of the BBC", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Since We've Become Translucent", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Under a Billion Suns", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Lucky Ones", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Mudhoney",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Digital Garbage", Label = "Sub Pop",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Last Words: The Final Recordings", Label = "Sunyata Productions",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Hole",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The First Session", Label = "Sympathy for the Record Industry",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Everclear",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "World of Noise", Label = "Tim/Kerr",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Skin Yard",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Hallowed Ground", Label = "Toxic Shock",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Sixteen Stone", Label = "Trauma Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Razorblade Suitcase", Label = "Trauma/Interscope",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Deconstructed", Label = "Trauma/Interscope",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Bush",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "The Science of Things", Label = "Trauma/Interscope",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Babes in Toyland",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Spanking Machine", Label = "Twin/Tone",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Babes in Toyland",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "To Mother", Label = "Twin/Tone",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Other Worlds", Label = "Velvetone",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Screaming Trees",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Clairvoyance", Label = "Velvetone",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Tad",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Inhaler", Label = "Warner Bros.",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "R.E.M.",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Monster", Label = "Warner Bros.",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Various artists",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Fuck Me I'm Rich", Label = "Waterfront Records",
						Genere = "Grunge"
					}
				}
			});

			list.Add(new DTO.Music.Album()
			{
				ArtistName = "Kid Cudi",
				CDList = new List<DTO.Music.CD>()
				{
					new DTO.Music.CD()
					{
						Name = "Speedin' Bullet 2 Heaven", Label = "Wicked Awesome/Republic",
						Genere = "Grunge"
					}
				}
			});

            return list;
        }
    }
}
