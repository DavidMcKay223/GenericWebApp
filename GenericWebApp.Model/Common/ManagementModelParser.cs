using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class ManagementModelParser
    {
        public static void ParseModel(GenericWebApp.Model.Management.TaskItem model, GenericWebApp.DTO.Management.TaskItem dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Title = dto.Title;
            model.Description = dto.Description;
            model.TaskObjectType_Code = dto.TaskObjectType_Code;
            model.Task_Object_ID = dto.Task_Object_ID;
            model.TaskActivity_ID = dto.TaskActivity_ID;
            model.CreatedDate = dto.CreatedDate;
            model.UpdatedDate = dto.UpdatedDate;
        }

        public static void ParseModel(GenericWebApp.Model.Management.TaskType model, GenericWebApp.DTO.Management.TaskType dto)
        {
            if (dto == null) return;

            model.Code = dto.Code;
            model.Description = dto.Description;
        }

        public static void ParseModel(GenericWebApp.Model.Management.TaskSubType model, GenericWebApp.DTO.Management.TaskSubType dto)
        {
            if (dto == null) return;

            model.Code = dto.Code;
            model.Description = dto.Description;
        }

        public static void ParseModel(GenericWebApp.Model.Management.TaskObjectType model, GenericWebApp.DTO.Management.TaskObjectType dto)
        {
            if (dto == null) return;

            model.Code = dto.Code;
            model.Description = dto.Description;
        }

        public static void ParseModel(GenericWebApp.Model.Management.TaskActivity model, GenericWebApp.DTO.Management.TaskActivity dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.TaskType_Code = dto.TaskType_Code;
            model.TaskSubType_Code = dto.TaskSubType_Code;
        }

        public static void ParseModel(GenericWebApp.Model.Management.CMS1500Form model, GenericWebApp.DTO.Management.CMS1500Form dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            ParseModel(model.Claimant, dto.Claimant);
            model.CreatedDate = dto.CreatedDate;
            model.UpdatedDate = dto.UpdatedDate;
        }

        public static void ParseModel(GenericWebApp.Model.Management.Claimant model, GenericWebApp.DTO.Management.Claimant dto)
        {
            if (dto == null) return;

            model.ID = dto.ID;
            model.Phone = dto.Phone;
            model.Name = dto.Name;
            model.Gender = dto.Gender;
            model.DateOfBirth = dto.DateOfBirth;
            model.InsurancePolicyNumber = dto.InsurancePolicyNumber;
            ParseModel(model.PrimaryAddress, dto.PrimaryAddress ?? new DTO.Management.Address());
            ParseModel(model.SecondaryAddress, dto.SecondaryAddress ?? new DTO.Management.Address());
        }

        public static void ParseModel(GenericWebApp.Model.Management.Address model, GenericWebApp.DTO.Management.Address dto)
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
