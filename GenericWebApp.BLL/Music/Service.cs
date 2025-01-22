using GenericWebApp.DTO.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Music
{
    public class Service : Common.ServiceManager<DTO.Music.Album, MusicSearchDTO>
    {
        public override async void SaveItem(Album dto)
        {
            Response.Error = null;

            if (Response.List.Count(x => String.Equals(x.ArtistName, dto.ArtistName)) == 0)
            {
                Response.List.Add(dto);
            }
            else
            {
                Response.Error = new DTO.Common.Error() { Message = "Artist Exists Already" };
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
                                    Length = 5.22M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 3,
                                    Title = "Giorgio By Moroder",
                                    Length = 9.04M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 4,
                                    Title = "Within",
                                    Length = 3.48M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 5,
                                    Title = "Instant Crush",
                                    Length = 5.37M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 6,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 7,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 8,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 9,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 10,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 11,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 12,
                                    Title = "",
                                    Length = 0M
                                },
                                new DTO.Music.Track()
                                {
                                    Number = 13,
                                    Title = "",
                                    Length = 0M
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
