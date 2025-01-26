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
    }
}
