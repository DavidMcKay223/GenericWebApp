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
