using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class TemplateDTOParser
    {
        public static GenericWebApp.DTO.Template.TemplateItem? ParseDTO(GenericWebApp.Model.Template.TemplateItem templateItem)
        {
            if (templateItem == null) return null;

            return new GenericWebApp.DTO.Template.TemplateItem
            {
                ID = templateItem.ID,
                Title = templateItem.Title,
                Description = templateItem.Description,
                TemplateStatus_ID = templateItem.TemplateStatus_ID,
                PrimaryAddress = ParseDTO(templateItem.PrimaryAddress)!,
                SecondaryAddress = ParseDTO(templateItem.SecondaryAddress)!,
                IsCompleted = templateItem.IsCompleted,
                CreatedDate = templateItem.CreatedDate,
                UpdatedDate = templateItem.UpdatedDate
            };
        }

        public static GenericWebApp.DTO.Template.TemplateStatus? ParseDTO(GenericWebApp.Model.Template.TemplateStatus templateStatus)
        {
            if (templateStatus == null) return null;
            return new GenericWebApp.DTO.Template.TemplateStatus
            {
                ID = templateStatus.ID,
                Description = templateStatus.Description
            };
        }

        public static GenericWebApp.DTO.Template.TemplateAddress? ParseDTO(GenericWebApp.Model.Template.TemplateAddress templateAddress)
        {
            if (templateAddress == null) return null;

            return new GenericWebApp.DTO.Template.TemplateAddress
            {
                ID = templateAddress.ID,
                Address1 = templateAddress.Address1,
                Address2 = templateAddress.Address2,
                City = templateAddress.City,
                State = templateAddress.State,
                Zip = templateAddress.Zip,
                Phone = templateAddress.Phone,
                Fax = templateAddress.Fax
            };
        }
    }
}
