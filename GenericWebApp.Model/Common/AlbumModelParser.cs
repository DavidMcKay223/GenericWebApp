﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class AlbumModelParser
    {
        public static void ParseModel(Model.Music.Album model, DTO.Music.Album dto)
        {
            if (dto == null) return;

            model.ID = dto.ID ?? 0;
            model.ArtistName = dto.ArtistName;

            model.CDList ??= [];

            foreach (DTO.Music.CD cdDto in dto.CDList ?? [])
            {
                var cdModel = model.CDList.FirstOrDefault(model => model.ID == cdDto.ID && cdDto.ID != 0);

                if (cdModel == null)
                {
                    cdModel = new Model.Music.CD() { Name = String.Empty, TrackList = [] };
                    model.CDList.Add(cdModel);
                }

                ParseModel(cdModel, cdDto);
            }
        }

        public static void ParseModel(Model.Music.CD model, DTO.Music.CD dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Name = dto.Name;
            model.Album_ID = dto.Album_ID;
            model.Genre_ID = dto.Genre_ID;

            model.TrackList ??= [];

            foreach (DTO.Music.Track trackDto in dto.TrackList ?? [])
            {
                var trackModel = model.TrackList.FirstOrDefault(model => model.ID == trackDto.ID && trackDto.ID != 0);

                if (trackModel == null)
                {
                    trackModel = new Model.Music.Track() { Title = String.Empty };
                    model.TrackList.Add(trackModel);
                }

                ParseModel(trackModel, trackDto);
            }
        }

        public static void ParseModel(Model.Music.Track model, DTO.Music.Track dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Number = dto.Number;
            model.Title = dto.Title;
            model.CD_ID = dto.CD_ID;
            model.Length = dto.Length;
        }

        public static void ParseModel(Model.Music.Genre model, DTO.Music.Genre dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Description = dto.Description;
        }
    }
}
