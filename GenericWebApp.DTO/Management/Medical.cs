using GenericWebApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.Management
{
    [Serializable]
    public class CMS1500Form
    {
        public Claimant Claimant { get; set; }
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            bool isValid = true;

            if (Claimant == null || !Claimant.IsValid(errorList))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidClaimant", Message = "Claimant information is invalid." });
            }

            if (CreatedDate == default)
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidCreatedDate", Message = "Created date is required." });
            }

            if (UpdatedDate == default)
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidUpdatedDate", Message = "Updated date is required." });
            }

            return isValid;
        }

        // Add other CMS1500 form fields as needed
    }

    [Serializable]
    public class Claimant
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string InsurancePolicyNumber { get; set; }
        public Address PrimaryAddress { get; set; }
        public Address SecondaryAddress { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(Name))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidName", Message = "Name is required." });
            }

            if (string.IsNullOrWhiteSpace(Gender))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidGender", Message = "Gender is required." });
            }

            if (DateOfBirth == default)
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidDateOfBirth", Message = "Date of birth is required." });
            }

            if (string.IsNullOrWhiteSpace(InsurancePolicyNumber))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidInsurancePolicyNumber", Message = "Insurance policy number is required." });
            }

            if (PrimaryAddress == null || !PrimaryAddress.IsValid(errorList))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidPrimaryAddress", Message = "Primary address is invalid." });
            }

            if (SecondaryAddress == null || !SecondaryAddress.IsValid(errorList))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidSecondaryAddress", Message = "Secondary address is invalid." });
            }

            return isValid;
        }

        // Add other claimant fields as needed
    }

    [Serializable]
    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public bool IsValid(List<Error> errorList)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(Address1))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidAddress1", Message = "Address1 is required." });
            }

            if (string.IsNullOrWhiteSpace(City))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidCity", Message = "City is required." });
            }

            if (string.IsNullOrWhiteSpace(State))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidState", Message = "State is required." });
            }

            if (string.IsNullOrWhiteSpace(Zip))
            {
                isValid = false;
                errorList.Add(new Error { Code = "InvalidZip", Message = "Zip code is required." });
            }

            return isValid;
        }
    }
}
