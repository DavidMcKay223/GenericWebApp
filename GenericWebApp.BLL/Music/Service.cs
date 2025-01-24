using GenericWebApp.DTO.Music;
using GenericWebApp.BLL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.Music
{
    public class Service : Common.ServiceManager<DTO.Music.Album, MusicSearchDTO>
    {
        public override void DeleteItem(Album dto)
        {
            Response.Error = null;

            // Delete Item from DB
            if (!Response.List.Remove(dto))
            {
                Response.Error = new DTO.Common.Error() { Message = "Item did not delete" };
            }
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
                Album tempAlbum = Response.List.Find(x => x.ArtistName == dto.ArtistName);
                if (tempAlbum != null && tempAlbum.CDList != null)
                {
                    tempAlbum.CDList = dto.CDList;
                }
            }
        }

        public override async Task<DTO.Music.Album> GetItem(MusicSearchDTO searchParams)
        {
            Response.Error = null;
            throw new NotImplementedException();
        }

        public override async Task<List<DTO.Music.Album>> GetList(MusicSearchDTO searchParams)
        {
            List<DTO.Music.Album> myList = Response.List;

            if (FirstRun)
            {
                Response.List = Music.Fake.FakeCallDB();

                List<String> tempStrList = Response.List.Select(x => x.ArtistName).Distinct().ToList();
                List<DTO.Music.Album> tempList = new List<Album>();

                foreach (String tempStr in tempStrList)
                {
                    tempList.Add(new Album() { ArtistName = tempStr, CDList = Response.List.Where(x => x.ArtistName == tempStr && x.CDList != null).SelectMany(x => x.CDList).ToList() });
                }

                Response.List = tempList;
                myList = Response.List;
                FirstRun = false;
            }

            if (searchParams != null)
            {
                if (!searchParams.ArtistName.IsNullOrWhiteSpace())
                {
                    myList = myList.Where(x => x.ArtistName.SafeString().Contains(searchParams.ArtistName, StringComparison.OrdinalIgnoreCase)).ToList();
                }

                if (!searchParams.CdName.IsNullOrWhiteSpace())
                {
                    myList = myList.Where(x => x.CDList != null && x.CDList.Any(y => y.Name.SafeString().Contains(searchParams.CdName, StringComparison.OrdinalIgnoreCase))).ToList();
                    myList = myList.Select(x => new Album
                    {
                        ArtistName = x.ArtistName,
                        CDList = x.CDList.Where(y => y.Name.SafeString().Contains(searchParams.CdName, StringComparison.OrdinalIgnoreCase)).ToList()
                    }).ToList();
                }

                if (!searchParams.CdLabel.IsNullOrWhiteSpace())
                {
                    myList = myList.Where(x => x.CDList != null && x.CDList.Any(y => y.Label.SafeString().Contains(searchParams.CdLabel, StringComparison.OrdinalIgnoreCase))).ToList();
                    myList = myList.Select(x => new Album
                    {
                        ArtistName = x.ArtistName,
                        CDList = x.CDList.Where(y => y.Label.SafeString().Contains(searchParams.CdLabel, StringComparison.OrdinalIgnoreCase)).ToList()
                    }).ToList();
                }

                if (!searchParams.TrackTitle.IsNullOrWhiteSpace())
                {
                    myList = myList.Where(x => x.CDList != null && x.CDList.Any(y => y.TrackList != null && y.TrackList.Any(z => z.Title.SafeString().Contains(searchParams.TrackTitle, StringComparison.OrdinalIgnoreCase)))).ToList();
                    myList = myList.Select(x => new Album
                    {
                        ArtistName = x.ArtistName,
                        CDList = x.CDList.Select(y => new CD
                        {
                            Name = y.Name,
                            Genre = y.Genre,
                            Label = y.Label,
                            TrackList = y.TrackList.Where(z => z.Title.SafeString().Contains(searchParams.TrackTitle, StringComparison.OrdinalIgnoreCase)).ToList()
                        }).Where(y => y.TrackList.Any()).ToList()
                    }).ToList();
                }
            }

            return myList;
        }
    }

    public class MusicSearchDTO
    {
        public string ArtistName { get; set; }
        public string CdName { get; set; }
        public string TrackTitle { get; set; }
        public string CdLabel { get; set; }
    }
}
