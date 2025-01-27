using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GenericWebApp.Model.Management
{
    [Table("Management_CMS1500Form")]
    public class CMS1500Form
    {
        [Key]
        public int ID { get; set; }
        public int ClaimantID { get; set; }
        public required Claimant Claimant { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }

    [Table("Management_Claimant")]
    public class Claimant
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(500)]
        public required string Name { get; set; }
        [MaxLength(20)]
        public string? Phone { get; set; }
        [MaxLength(10)]
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        [MaxLength(50)]
        public string? InsurancePolicyNumber { get; set; }
        public int PrimaryAddressID { get; set; }
        public int SecondaryAddressID { get; set; }
        public required Address PrimaryAddress { get; set; }
        public required Address SecondaryAddress { get; set; }
    }

    [Table("Management_Address")]
    public class Address
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
