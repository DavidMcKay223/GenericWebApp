using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Management
{
    [Table("Management_TaskItem")]
    public class TaskItem
    {
        [Key]
        public int? ID { get; set; }

        [MaxLength(500)]
        public string Title { get; set; }

        public string Description { get; set; }

        [MaxLength(10)]
        public string? TaskObjectType_Code { get; set; }

        public int? Task_Object_ID { get; set; }

        public int? TaskActivity_ID { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }
    }

    [Table("Management_TaskType")]
    public class TaskType
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }
    }

    [Table("Management_TaskSubType")]
    public class TaskSubType
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }
    }

    [Table("Management_TaskObjectType")]
    public class TaskObjectType
    {
        [Key]
        [MaxLength(10)]
        public string Code { get; set; }

        public string Description { get; set; }
    }

    [Table("Management_TaskActivity")]
    public class TaskActivity
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(10)]
        public string TaskType_Code { get; set; }

        [MaxLength(10)]
        public string TaskSubType_Code { get; set; }
    }
}
