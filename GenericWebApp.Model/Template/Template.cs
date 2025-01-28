using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Template
{
    [Table("Template_TemplateItem")]
    public class TemplateItem
    {
        [Key]
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

    [Table("Template_TemplateStatus")]
    public class TemplateStatus
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public required string Description { get; set; }
    }
}
