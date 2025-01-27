using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GenericWebApp.DTO.Management
{
    public class TaskItem : EntityDTO
    {
        public int? ID { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(500, ErrorMessage = "Title cannot exceed 500 characters")]
        public required string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public required string Description { get; set; }

        public string? TaskObjectType_Code { get; set; }
        public int? Task_Object_ID { get; set; }
        public int? TaskActivity_ID { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public new bool IsValid(List<Error> errorList)
        {
            if (String.IsNullOrEmpty(Title))
            {
                errorList.Add(new Error { Code = "DTO.Invalid", Message = "Task Title Required" });
            }

            if (String.IsNullOrEmpty(Description))
            {
                errorList.Add(new Error { Code = "DTO.Invalid", Message = "Task Description Required" });
            }

            return errorList.Count == 0;
        }
    }

    public class TaskType : EntityDTO
    {
        public required string Code { get; set; }
        public required string Description { get; set; }
    }

    public class TaskSubType : EntityDTO
    {
        public required string Code { get; set; }
        public required string Description { get; set; }

        public TaskSubType()
        {
            Code = String.Empty;
            Description = String.Empty;
        }
    }

    public class TaskObjectType : EntityDTO
    {
        public required string Code { get; set; }
        public required string Description { get; set; }
    }

    public class TaskActivity : EntityDTO
    {
        public int ID { get; set; }
        public required string TaskType_Code { get; set; }
        public required string TaskSubType_Code { get; set; }
    }
}
