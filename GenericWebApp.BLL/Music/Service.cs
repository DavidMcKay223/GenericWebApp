using GenericWebApp.DTO.Music;
using GenericWebApp.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Music
{
    public class Service : Common.ServiceManager<DTO.Music.Album, MusicSearchDTO>
    {
        public override void DeleteItem(Album dto)
        {
            //Delete Item from DB
            Response.List.Remove(dto);
        }

        public override async void SaveItem(Album dto, Boolean isNew = false)
        {
            Response.Error = null;

            if (isNew)
            {
                if (Response.List.Count(x => String.Equals(x.ArtistName, dto.ArtistName, StringComparison.OrdinalIgnoreCase)) == 0)
                {
                    Response.List.Add(dto);
                }
                else
                {
                    Response.Error = new DTO.Common.Error() { Message = "Artist Exists Already" };
                }
            }
            else
            {
                //Save Album Changes to DB
            }
        }

        public override async Task<DTO.Music.Album> GetItem(MusicSearchDTO searchParams)
        {
            Response.Error = null;

            throw new NotImplementedException();
        }

        public override async Task<List<DTO.Music.Album>> GetList(MusicSearchDTO searchParams)
        {
            Response.Error = null;

            if (Response.List != null && Response.List.Count == 0)
            {
                Response.List = FakeCallDB();

                if(searchParams != null && !searchParams.ArtistName.IsNullOrWhiteSpace())
                {
                    Response.List = Response.List.Where(x => x.ArtistName.Contains(searchParams.ArtistName)).ToList();
                }
            }

            return Response.List;
        }

        private List<Album> FakeCallDB()
        {
            List<Album> list = new List<Album>();

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

            return list;
        }
    }

    public class MusicSearchDTO
    {
        public string ArtistName { get; set; }
    }
}
