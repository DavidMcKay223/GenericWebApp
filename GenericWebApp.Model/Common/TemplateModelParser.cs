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
        }

        public static void ParseModel(GenericWebApp.Model.Template.TemplateStatus model, GenericWebApp.DTO.Template.TemplateStatus dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Description = dto.Description;
        }
    }
}
