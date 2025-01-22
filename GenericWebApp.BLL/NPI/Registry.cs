﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericWebApp.BLL.Common;

namespace GenericWebApp.BLL.NPI
{
    public class Registry
    {
        public static async Task<DTO.Common.Response<DTO.NPI.Provider>> GetProviderList(RegistrySearchDTO searchDTO = null)
        {
            DTO.Common.Response<DTO.NPI.Provider> myResponse = new DTO.Common.Response<DTO.NPI.Provider>();

            if (searchDTO == null) return myResponse;

            String endpoint = "https://npiregistry.cms.hhs.gov/api/";

            String myJsonResponse = await endpoint.GetUriToJson(searchDTO.GetSearchParameter());

            GenericWebApp.BLL.NPI.Parser.Root? myRoot = JsonConvert.DeserializeObject<GenericWebApp.BLL.NPI.Parser.Root>(myJsonResponse);

            if (myRoot != null && myRoot.Errors != null && myRoot.Errors.Count > 0)
            {
                myResponse.Error = new DTO.Common.Error() { Message = String.Join("\r\n", myRoot.Errors.Select(x => x.description)) };
            }
            else if (myRoot != null && myRoot.results != null)
            {
                List<DTO.NPI.Provider> providerList = new List<DTO.NPI.Provider>();
                myResponse.List = providerList;

                foreach (Parser.Result myProvider in myRoot.results)
                {
                    providerList.Add(ParseProvider(myProvider));
                }
            }

            return myResponse;
        }

        private static DTO.NPI.Provider ParseProvider(Parser.Result myProvider)
        {
            if(myProvider == null) return null;

            DTO.NPI.Provider npiProvider = new DTO.NPI.Provider() { NPI = myProvider.number };

            if (myProvider.addresses != null && myProvider.addresses.Count > 0)
            {
                Parser.Address tempAddress = myProvider.addresses[0];

                npiProvider.Address1 = tempAddress.address_1;
                npiProvider.Address2 = tempAddress.address_2;
                npiProvider.City = tempAddress.city;
                npiProvider.State = tempAddress.state;
                npiProvider.Zip = tempAddress.postal_code;
                npiProvider.Phone = tempAddress.telephone_number;
                npiProvider.Fax = tempAddress.fax_number;
            }

            if (myProvider.addresses != null && myProvider.addresses.Count > 1)
            {
                Parser.Address tempAddress = myProvider.addresses[1];

                npiProvider.MailingAddress1 = tempAddress.address_1;
                npiProvider.MailingAddress2 = tempAddress.address_2;
                npiProvider.MailingCity = tempAddress.city;
                npiProvider.MailingState = tempAddress.state;
                npiProvider.MailingZip = tempAddress.postal_code;
                npiProvider.MailingPhone = tempAddress.telephone_number;
                npiProvider.MailingFax = tempAddress.fax_number;
            }

            if (myProvider.basic != null)
            {
                npiProvider.Name = myProvider.basic.name;
                npiProvider.ProviderName = myProvider.basic.last_name + ", " + myProvider.basic.first_name;
                npiProvider.ProviderFirstName = myProvider.basic.first_name;
                npiProvider.ProviderLastName = myProvider.basic.last_name;
                npiProvider.OrganizationName = myProvider.basic.organization_name;
                npiProvider.ParentOrganizationLegalBusinessName = myProvider.basic.parent_organization_legal_business_name;
            }

            if (myProvider.other_names != null && myProvider.other_names.Count > 0)
            {
                npiProvider.OtherOrganizationName = myProvider.other_names[0].organization_name;
            }

            if (myProvider.taxonomies != null)
            {
                Parser.Taxonomy temp = myProvider.taxonomies.Where(x => x.primary == true).FirstOrDefault();

                if (temp != null)
                {
                    npiProvider.PrimaryTaxonomyCode = temp.code;
                    npiProvider.PrimaryTaxonomyStateLicense = (!String.IsNullOrWhiteSpace(temp.license) ? String.Format("{0}{1}", (temp.license.Contains(temp.state) ? "" : temp.state), temp.license) : "");
                }
            }

            return npiProvider;
        }
    }

    public class RegistrySearchDTO
    {
        public string number { get; set; }
        public string enumeration_type { get; set; }
        public string taxonomy_description { get; set; }
        public string name_purpose { get; set; }
        public string first_name { get; set; }
        public string use_first_name_alias { get; set; }
        public string last_name { get; set; }
        public string organization_name { get; set; }
        public string address_purpose { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string country_code { get; set; }
        public string limit { get; set; }
        public string skip { get; set; }
        public string pretty { get; set; }
        public string version { get { return "2.1"; } }


        public string GetSearchParameter()
        {
            List<String> parameterList = new List<string>();

            parameterList.Add(String.Format("number={0}", number));
            parameterList.Add(String.Format("enumeration_type={0}", enumeration_type));
            parameterList.Add(String.Format("taxonomy_description={0}", taxonomy_description));
            parameterList.Add(String.Format("name_purpose={0}", name_purpose));
            parameterList.Add(String.Format("first_name={0}", first_name));
            parameterList.Add(String.Format("use_first_name_alias={0}", use_first_name_alias));
            parameterList.Add(String.Format("last_name={0}", last_name));
            parameterList.Add(String.Format("organization_name={0}", organization_name));
            parameterList.Add(String.Format("address_purpose={0}", address_purpose));
            parameterList.Add(String.Format("city={0}", city));
            parameterList.Add(String.Format("state={0}", state));
            parameterList.Add(String.Format("postal_code={0}", postal_code));
            parameterList.Add(String.Format("country_code={0}", country_code));
            parameterList.Add(String.Format("limit={0}", limit));
            parameterList.Add(String.Format("skip={0}", skip));
            parameterList.Add(String.Format("pretty={0}", pretty));
            parameterList.Add(String.Format("version={0}", version));

            return String.Join("&", parameterList);
        }
    }
}

namespace GenericWebApp.BLL.NPI.Parser
{
    internal class Address
    {
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string address_purpose { get; set; }
        public string address_type { get; set; }
        public string address_1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string telephone_number { get; set; }
        public string fax_number { get; set; }
        public string address_2 { get; set; }
    }

    internal class Basic
    {
        public string organization_name { get; set; }
        public string organizational_subpart { get; set; }
        public string enumeration_date { get; set; }
        public string last_updated { get; set; }
        public string certification_date { get; set; }
        public string status { get; set; }
        public string authorized_official_first_name { get; set; }
        public string authorized_official_last_name { get; set; }
        public string authorized_official_telephone_number { get; set; }
        public string authorized_official_title_or_position { get; set; }
        public string authorized_official_name_prefix { get; set; }
        public string authorized_official_name_suffix { get; set; }
        public string authorized_official_credential { get; set; }
        public string authorized_official_middle_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string middle_name { get; set; }
        public string sole_proprietor { get; set; }
        public string gender { get; set; }
        public string name_prefix { get; set; }
        public string parent_organization_legal_business_name { get; internal set; }
        public string name { get; internal set; }
    }

    internal class Endpoint
    {
        public string endpointType { get; set; }
        public string endpointTypeDescription { get; set; }
        public string endpoint { get; set; }
        public string affiliation { get; set; }
        public string useDescription { get; set; }
        public string contentTypeDescription { get; set; }
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string address_type { get; set; }
        public string address_1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
    }

    internal class Identifier
    {
        public string code { get; set; }
        public string desc { get; set; }
        public string issuer { get; set; }
        public string identifier { get; set; }
        public string state { get; set; }
    }

    internal class OtherName
    {
        public string organization_name { get; set; }
        public string type { get; set; }
        public string code { get; set; }
    }

    internal class PracticeLocation
    {
        public string country_code { get; set; }
        public string country_name { get; set; }
        public string address_purpose { get; set; }
        public string address_type { get; set; }
        public string address_1 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postal_code { get; set; }
        public string telephone_number { get; set; }
        public string fax_number { get; set; }
    }

    internal class Result
    {
        public string created_epoch { get; set; }
        public string enumeration_type { get; set; }
        public string last_updated_epoch { get; set; }
        public string number { get; set; }
        public List<Address> addresses { get; set; }
        public List<PracticeLocation> practiceLocations { get; set; }
        public Basic basic { get; set; }
        public List<Taxonomy> taxonomies { get; set; }
        public List<Identifier> identifiers { get; set; }
        public List<Endpoint> endpoints { get; set; }
        public List<OtherName> other_names { get; set; }
    }

    public class Error
    {
        public string description { get; set; }
        public string field { get; set; }
        public string number { get; set; }
    }

    internal class Root
    {
        public int result_count { get; set; }
        public List<Result> results { get; set; }
        public List<Error> Errors { get; set; }
    }

    internal class Taxonomy
    {
        public string code { get; set; }
        public string taxonomy_group { get; set; }
        public string desc { get; set; }
        public string state { get; set; }
        public string license { get; set; }
        public bool primary { get; set; }
    }
}
