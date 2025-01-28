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

        public required TemplateAddress PrimaryAddress { get; set; }
        public required TemplateAddress? SecondaryAddress { get; set; }

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

    [Serializable]
    public class TemplateAddress : EntityDTO
    {
        public int ID { get; set; }

        [MaxLength(500, ErrorMessage = "Address1 cannot exceed 500 characters")]
        public string? Address1 { get; set; }

        [MaxLength(500, ErrorMessage = "Address2 cannot exceed 500 characters")]
        public string? Address2 { get; set; }

        [MaxLength(100, ErrorMessage = "City cannot exceed 100 characters")]
        public string? City { get; set; }

        [MaxLength(100, ErrorMessage = "State cannot exceed 100 characters")]
        public string? State { get; set; }

        [MaxLength(20, ErrorMessage = "Zip cannot exceed 20 characters")]
        public string? Zip { get; set; }

        [MaxLength(20, ErrorMessage = "Phone cannot exceed 20 characters")]
        public string? Phone { get; set; }

        [MaxLength(20, ErrorMessage = "Fax cannot exceed 20 characters")]
        public string? Fax { get; set; }
    }
}
