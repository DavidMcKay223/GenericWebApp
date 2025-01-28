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

        [ForeignKey("PrimaryAddressID")]
        public int PrimaryAddressID { get; set; }

        [ForeignKey("SecondaryAddressID")]
        public int SecondaryAddressID { get; set; }

        [ForeignKey("TemplateStatus_ID")]
        public int TemplateStatus_ID { get; set; }

        public required Boolean IsCompleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public required TemplateAddress PrimaryAddress { get; set; }
        public required TemplateAddress SecondaryAddress { get; set; }
    }

    [Table("Template_TemplateStatus")]
    public class TemplateStatus
    {
        [Key]
        public int ID { get; set; }

        [MaxLength(100)]
        public required string Description { get; set; }
    }

    [Table("Template_TemplateAddress")]
    public class TemplateAddress
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(500)]
        public string? Address1 { get; set; }
        [MaxLength(500)]
        public string? Address2 { get; set; }
        [MaxLength(100)]
        public string? City { get; set; }
        [MaxLength(100)]
        public string? State { get; set; }
        [MaxLength(20)]
        public string? Zip { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(20)]
        public string? Fax { get; set; }
    }

}
