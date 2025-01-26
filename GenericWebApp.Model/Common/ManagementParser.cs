using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.Model.Common
{
    public static class ManagementParser
    {
        public static GenericWebApp.DTO.Management.TaskItem ParseDTO(GenericWebApp.Model.Management.TaskItem taskItem)
        {
            if (taskItem == null) return null;

            GenericWebApp.DTO.Management.TaskItem dto = new GenericWebApp.DTO.Management.TaskItem
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

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskItem ParseModel(GenericWebApp.DTO.Management.TaskItem dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskItem taskItem = new GenericWebApp.Model.Management.TaskItem
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description,
                TaskObjectType_Code = dto.TaskObjectType_Code,
                Task_Object_ID = dto.Task_Object_ID,
                TaskActivity_ID = dto.TaskActivity_ID,
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate
            };

            return taskItem;
        }

        public static GenericWebApp.DTO.Management.TaskType ParseDTO(GenericWebApp.Model.Management.TaskType taskType)
        {
            if (taskType == null) return null;

            GenericWebApp.DTO.Management.TaskType dto = new GenericWebApp.DTO.Management.TaskType
            {
                Code = taskType.Code,
                Description = taskType.Description
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskType ParseModel(GenericWebApp.DTO.Management.TaskType dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskType taskType = new GenericWebApp.Model.Management.TaskType
            {
                Code = dto.Code,
                Description = dto.Description
            };

            return taskType;
        }

        public static GenericWebApp.DTO.Management.TaskSubType ParseDTO(GenericWebApp.Model.Management.TaskSubType taskSubType)
        {
            if (taskSubType == null) return null;

            GenericWebApp.DTO.Management.TaskSubType dto = new GenericWebApp.DTO.Management.TaskSubType
            {
                Code = taskSubType.Code,
                Description = taskSubType.Description
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskSubType ParseModel(GenericWebApp.DTO.Management.TaskSubType dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskSubType taskSubType = new GenericWebApp.Model.Management.TaskSubType
            {
                Code = dto.Code,
                Description = dto.Description
            };

            return taskSubType;
        }

        public static GenericWebApp.DTO.Management.TaskObjectType ParseDTO(GenericWebApp.Model.Management.TaskObjectType taskObjectType)
        {
            if (taskObjectType == null) return null;

            GenericWebApp.DTO.Management.TaskObjectType dto = new GenericWebApp.DTO.Management.TaskObjectType
            {
                Code = taskObjectType.Code,
                Description = taskObjectType.Description
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskObjectType ParseModel(GenericWebApp.DTO.Management.TaskObjectType dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskObjectType taskObjectType = new GenericWebApp.Model.Management.TaskObjectType
            {
                Code = dto.Code,
                Description = dto.Description
            };

            return taskObjectType;
        }

        public static GenericWebApp.DTO.Management.TaskActivity ParseDTO(GenericWebApp.Model.Management.TaskActivity taskActivity)
        {
            if (taskActivity == null) return null;

            GenericWebApp.DTO.Management.TaskActivity dto = new GenericWebApp.DTO.Management.TaskActivity
            {
                ID = taskActivity.ID,
                TaskType_Code = taskActivity.TaskType_Code,
                TaskSubType_Code = taskActivity.TaskSubType_Code
            };

            return dto;
        }

        public static GenericWebApp.Model.Management.TaskActivity ParseModel(GenericWebApp.DTO.Management.TaskActivity dto)
        {
            if (dto == null) return null;

            GenericWebApp.Model.Management.TaskActivity taskActivity = new GenericWebApp.Model.Management.TaskActivity
            {
                ID = dto.ID,
                TaskType_Code = dto.TaskType_Code,
                TaskSubType_Code = dto.TaskSubType_Code
            };

            return taskActivity;
        }

        public static GenericWebApp.DTO.Management.CMS1500Form ParseDTO(GenericWebApp.Model.Management.CMS1500Form cms1500Form)
        {
            if (cms1500Form == null) return null;

            return new GenericWebApp.DTO.Management.CMS1500Form
            {
                ID = cms1500Form.ID,
                Claimant = ParseDTO(cms1500Form.Claimant),
                CreatedDate = cms1500Form.CreatedDate,
                UpdatedDate = cms1500Form.UpdatedDate
            };
        }

        public static GenericWebApp.Model.Management.CMS1500Form ParseModel(GenericWebApp.DTO.Management.CMS1500Form dto)
        {
            if (dto == null) return null;

            return new GenericWebApp.Model.Management.CMS1500Form
            {
                ID = dto.ID,
                Claimant = ParseModel(dto.Claimant),
                CreatedDate = dto.CreatedDate,
                UpdatedDate = dto.UpdatedDate
            };
        }

        public static GenericWebApp.DTO.Management.Claimant ParseDTO(GenericWebApp.Model.Management.Claimant claimant)
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

        public static GenericWebApp.Model.Management.Claimant ParseModel(GenericWebApp.DTO.Management.Claimant dto)
        {
            if (dto == null) return null;

            return new GenericWebApp.Model.Management.Claimant
            {
                ID = dto.ID,
                Phone = dto.Phone,
                Name = dto.Name,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                InsurancePolicyNumber = dto.InsurancePolicyNumber,
                PrimaryAddress = ParseModel(dto.PrimaryAddress),
                SecondaryAddress = ParseModel(dto.SecondaryAddress)
            };
        }

        public static GenericWebApp.DTO.Management.Address ParseDTO(GenericWebApp.Model.Management.Address address)
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

        public static GenericWebApp.Model.Management.Address ParseModel(GenericWebApp.DTO.Management.Address dto)
        {
            if (dto == null) return null;

            return new GenericWebApp.Model.Management.Address
            {
                ID = dto.ID,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                City = dto.City,
                State = dto.State,
                Zip = dto.Zip,
                Phone = dto.Phone,
                Fax = dto.Fax
            };
        }
    }
}
