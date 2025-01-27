using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class ManagementDTOParser
    {
        public static GenericWebApp.DTO.Management.TaskItem? ParseDTO(GenericWebApp.Model.Management.TaskItem taskItem)
        {
            if (taskItem == null) return null;

            return new GenericWebApp.DTO.Management.TaskItem
            {
                ID = taskItem.ID,
                Title = taskItem.Title,
                Description = taskItem.Description,
                TaskObjectType_Code = taskItem.TaskObjectType_Code,
                Task_Object_ID = taskItem.Task_Object_ID,
                TaskActivity_ID = taskItem.TaskActivity_ID,
                CreatedDate = taskItem.CreatedDate,
                UpdatedDate = taskItem.UpdatedDate
            };
        }

        public static GenericWebApp.DTO.Management.TaskType? ParseDTO(GenericWebApp.Model.Management.TaskType taskType)
        {
            if (taskType == null) return null;

            return new GenericWebApp.DTO.Management.TaskType
            {
                Code = taskType.Code,
                Description = taskType.Description
            };
        }

        public static GenericWebApp.DTO.Management.TaskSubType? ParseDTO(GenericWebApp.Model.Management.TaskSubType taskSubType)
        {
            if (taskSubType == null) return null;

            return new GenericWebApp.DTO.Management.TaskSubType
            {
                Code = taskSubType.Code,
                Description = taskSubType.Description
            };
        }

        public static GenericWebApp.DTO.Management.TaskObjectType? ParseDTO(GenericWebApp.Model.Management.TaskObjectType taskObjectType)
        {
            if (taskObjectType == null) return null;

            return new GenericWebApp.DTO.Management.TaskObjectType
            {
                Code = taskObjectType.Code,
                Description = taskObjectType.Description
            };
        }

        public static GenericWebApp.DTO.Management.TaskActivity? ParseDTO(GenericWebApp.Model.Management.TaskActivity taskActivity)
        {
            if (taskActivity == null) return null;

            return new GenericWebApp.DTO.Management.TaskActivity
            {
                ID = taskActivity.ID,
                TaskType_Code = taskActivity.TaskType_Code,
                TaskSubType_Code = taskActivity.TaskSubType_Code
            };
        }

        public static GenericWebApp.DTO.Management.CMS1500Form? ParseDTO(GenericWebApp.Model.Management.CMS1500Form cms1500Form)
        {
            if (cms1500Form == null) return null;

            return new GenericWebApp.DTO.Management.CMS1500Form
            {
                ID = cms1500Form.ID,
                Claimant = ParseDTO(cms1500Form.Claimant) ?? new DTO.Management.Claimant() { Name = String.Empty },
                CreatedDate = cms1500Form.CreatedDate,
                UpdatedDate = cms1500Form.UpdatedDate
            };
        }

        public static GenericWebApp.DTO.Management.Claimant? ParseDTO(GenericWebApp.Model.Management.Claimant claimant)
        {
            if (claimant == null) return null;

            return new GenericWebApp.DTO.Management.Claimant
            {
                ID = claimant.ID,
                Name = claimant.Name,
                Gender = claimant.Gender,
                Phone = claimant.Phone,
                DateOfBirth = claimant.DateOfBirth,
                InsurancePolicyNumber = claimant.InsurancePolicyNumber,
                PrimaryAddress = ParseDTO(claimant.PrimaryAddress),
                SecondaryAddress = ParseDTO(claimant.SecondaryAddress)
            };
        }

        public static GenericWebApp.DTO.Management.Address? ParseDTO(GenericWebApp.Model.Management.Address address)
        {
            if (address == null) return null;

            return new GenericWebApp.DTO.Management.Address
            {
                ID = address.ID,
                Address1 = address.Address1,
                Address2 = address.Address2,
                City = address.City,
                State = address.State,
                Zip = address.Zip,
                Phone = address.Phone,
                Fax = address.Fax
            };
        }
    }
}
