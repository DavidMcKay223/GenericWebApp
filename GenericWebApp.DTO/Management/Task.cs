﻿using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Management
{
    public class TaskItem
    {
        public int? ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string TaskObjectType_Code { get; set; }
        public int? Task_Object_ID { get; set; }
        public int? TaskActivity_ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            if (String.IsNullOrEmpty(Title))
            {
                errorList.Add(new Error { Message = "Task Title Required" });
            }

            if (String.IsNullOrEmpty(Description))
            {
                errorList.Add(new Error { Message = "Task Description Required" });
            }

            return errorList.Count == 0;
        }
    }

    public class TaskType
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class TaskSubType
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class TaskObjectType
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class TaskActivity
    {
        public int ID { get; set; }
        public string TaskType_Code { get; set; }
        public string TaskSubType_Code { get; set; }
    }
}
