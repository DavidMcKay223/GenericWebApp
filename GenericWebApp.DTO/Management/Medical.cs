using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Management
{
    [Serializable]
    public class CMS1500Form
    {
        public int ID { get; set; }

        [Required]
        public Claimant Claimant { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            bool isValid = true;

            if (Claimant == null || !Claimant.IsValid(errorList))
            {
                isValid = false;
            }

            return isValid;
        }
    }

    [Serializable]
    public class Claimant
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(500, ErrorMessage = "Name cannot exceed 500 characters")]
        public string Name { get; set; }

        [MaxLength(20, ErrorMessage = "Phone cannot exceed 20 characters")]
        public string Phone { get; set; }

        [MaxLength(10, ErrorMessage = "Gender cannot exceed 10 characters")]
        public string Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(50, ErrorMessage = "Insurance Policy Number cannot exceed 50 characters")]
        public string InsurancePolicyNumber { get; set; }

        [Required(ErrorMessage = "Primary Address is required")]
        public Address PrimaryAddress { get; set; }

        [Required(ErrorMessage = "Secondary Address is required")]
        public Address SecondaryAddress { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(Name))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidName", Message = "Name is required." });
            }

            if (PrimaryAddress == null || !PrimaryAddress.IsValid(errorList))
            {
                isValid = false;
            }

            if (SecondaryAddress == null || !SecondaryAddress.IsValid(errorList))
            {
                isValid = false;
            }

            return isValid;
        }
    }

    [Serializable]
    public class Address
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

        public bool IsValid(List<Error> errorList)
        {
            bool isValid = true;

            return isValid;
        }
    }
}
