using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.NPI
{
    [Serializable]
    public class Provider
    {
        #region -- NPI Number --
        public string NPI { get; set; }
        #endregion

        #region -- Address Info --
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        #endregion

        #region -- Mailing Address Info --
        public string MailingAddress1 { get; set; }
        public string MailingAddress2 { get; set; }
        public string MailingCity { get; set; }
        public string MailingState { get; set; }
        public string MailingZip { get; set; }
        public string MailingPhone { get; set; }
        public string MailingFax { get; set; }
        #endregion

        #region -- Basic Info --
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        public string OrganizationName { get; set; }
        public string ParentOrganizationLegalBusinessName { get; set; }
        #endregion

        #region -- Other Names --
        public string OtherOrganizationName { get; set; }
        #endregion

        #region -- Taxonomy --
        public string PrimaryTaxonomyCode { get; set; }
        public string PrimaryTaxonomyStateLicense { get; set; }
        #endregion

        #region -- Dynamic --
        public string DynamicName
        {
            get
            {
                return (String.IsNullOrWhiteSpace(OtherOrganizationName) ? Name : OtherOrganizationName);
            }
        }

        public string DynamicLegalName
        {
            get
            {
                return (String.IsNullOrWhiteSpace(ParentOrganizationLegalBusinessName) ? Name : ParentOrganizationLegalBusinessName);
            }
        }
        #endregion
    }
}
