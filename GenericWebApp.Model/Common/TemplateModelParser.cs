using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class TemplateModelParser
    {
        public static void ParseModel(GenericWebApp.Model.Template.TemplateItem model, GenericWebApp.DTO.Template.TemplateItem dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Title = dto.Title;
            model.Description = dto.Description;
            model.TemplateStatus_ID = dto.TemplateStatus_ID;
            model.IsCompleted = dto.IsCompleted;
            model.CreatedDate = dto.CreatedDate;
            model.UpdatedDate = dto.UpdatedDate;

            ParseModel(model.PrimaryAddress, dto.PrimaryAddress ?? new DTO.Template.TemplateAddress());
            ParseModel(model.SecondaryAddress, dto.SecondaryAddress ?? new DTO.Template.TemplateAddress());
        }

        public static void ParseModel(GenericWebApp.Model.Template.TemplateStatus model, GenericWebApp.DTO.Template.TemplateStatus dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Description = dto.Description;
        }

        public static void ParseModel(GenericWebApp.Model.Template.TemplateAddress model, GenericWebApp.DTO.Template.TemplateAddress dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Address1 = dto.Address1;
            model.Address2 = dto.Address2;
            model.City = dto.City;
            model.State = dto.State;
            model.Zip = dto.Zip;
            model.Phone = dto.Phone;
            model.Fax = dto.Fax;
        }
    }
}
