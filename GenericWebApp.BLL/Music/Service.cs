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
            Response.Error = null;

            //Delete Item from DB
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
                if(tempAlbum.CDList != null)
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
                Boolean subFilter = false;

                if (!searchParams.ArtistName.IsNullOrWhiteSpace())
                {
                    myList = Response.List.Where(x => x.ArtistName.SafeString().Contains(searchParams.ArtistName, StringComparison.OrdinalIgnoreCase)).ToList();
                    subFilter = true;
                }

                if (!searchParams.CdName.IsNullOrWhiteSpace())
                {
                    if (subFilter)
                    {
                        myList = myList.Where(x => x.CDList != null && x.CDList.Any(y => y.Name.SafeString().Contains(searchParams.CdName, StringComparison.OrdinalIgnoreCase))).ToList();
                        
                    }
                    else
                    {
                        myList = Response.List.Where(x => x.CDList != null && x.CDList.Any(y => y.Name.SafeString().Contains(searchParams.CdName, StringComparison.OrdinalIgnoreCase))).ToList();
                        subFilter = true;
                    }

                    List<DTO.Music.Album> tempList = new List<Album>();
                    foreach (DTO.Music.Album album in myList)
                    {
                        tempList.Add(new Album() { ArtistName = album.ArtistName, CDList = album.CDList.Where(x => x.Name.SafeString().Contains(searchParams.CdName, StringComparison.OrdinalIgnoreCase)).ToList() });
                    }

                    myList = tempList;
                }

                if (!searchParams.CdLabel.IsNullOrWhiteSpace())
                {
                    if (subFilter)
                    {
                        myList = myList.Where(x => x.CDList != null && x.CDList.Any(y => y.Label.SafeString().Contains(searchParams.CdLabel, StringComparison.OrdinalIgnoreCase))).ToList();

                    }
                    else
                    {
                        myList = Response.List.Where(x => x.CDList != null && x.CDList.Any(y => y.Label.SafeString().Contains(searchParams.CdLabel, StringComparison.OrdinalIgnoreCase))).ToList();
                        subFilter = true;
                    }

                    List<DTO.Music.Album> tempList = new List<Album>();
                    foreach (DTO.Music.Album album in myList)
                    {
                        tempList.Add(new Album() { ArtistName = album.ArtistName, CDList = album.CDList.Where(x => x.Label.SafeString().Contains(searchParams.CdLabel, StringComparison.OrdinalIgnoreCase)).ToList() });
                    }

                    myList = tempList;
                }

                if (!searchParams.TrackTitle.IsNullOrWhiteSpace())
                {
                    if (subFilter)
                    {
                        myList = myList.Where(x => x.CDList != null && x.CDList.Any(y => y.TrackList != null && y.TrackList.Any(z => z.Title.SafeString().Contains(searchParams.TrackTitle, StringComparison.OrdinalIgnoreCase)))).ToList();
                    }
                    else
                    {
                        myList = Response.List.Where(x => x.CDList != null && x.CDList.Any(y => y.TrackList != null && y.TrackList.Any(z => z.Title.SafeString().Contains(searchParams.TrackTitle, StringComparison.OrdinalIgnoreCase)))).ToList();
                        subFilter = true;
                    }

                    List<DTO.Music.Album> tempList = new List<Album>();
                    foreach (DTO.Music.Album album in myList)
                    {
                        List<DTO.Music.CD> tempCdList = new List<CD>();

                        foreach (DTO.Music.CD cd in album.CDList)
                        {
                            if (cd.TrackList != null)
                            {
                                DTO.Music.CD tempCd = new DTO.Music.CD() { Name = cd.Name, Genere = cd.Genere };
                                tempCd.TrackList = cd.TrackList.Where(x => x.Title.SafeString().Contains(searchParams.TrackTitle, StringComparison.OrdinalIgnoreCase)).ToList();

                                tempCdList.Add(tempCd);
                            }
                        }

                        tempList.Add(new Album() { ArtistName = album.ArtistName, CDList = new List<CD>(tempCdList) });
                    }

                    myList = tempList;
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
