using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GenericWebApp.DTO.Template
{
    public class TemplateItem : EntityDTO
    {
        public int ID { get; set; }

        [MaxLength(100)]
        public required string Title { get; set; }

        [MaxLength(500)]
        public required string Description { get; set; }

        public int TemplateStatus_ID { get; set; }
        public required Boolean IsCompleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    public class TemplateStatus : EntityDTO
    {
        public int ID { get; set; }

        [MaxLength(100)]
        public required string Description { get; set; }
    }
}
