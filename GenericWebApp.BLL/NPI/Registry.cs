using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWebApp.BLL.Common;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericWebApp.BLL.Common;

namespace GenericWebApp.BLL.NPI
{
    public class Registry
    {
        private const string Endpoint = "https://npiregistry.cms.hhs.gov/api/";

        public static async Task<DTO.Common.Response<DTO.NPI.Provider>> GetProviderList(RegistrySearchDTO searchDTO = null)
        {
            var response = new DTO.Common.Response<DTO.NPI.Provider>();

            if (searchDTO == null) return response;

            var jsonResponse = await Endpoint.GetUriToJson(searchDTO.GetSearchParameter());
            var root = JsonConvert.DeserializeObject<Parser.Root>(jsonResponse);

            if (root?.Errors?.Count > 0)
            {
                response.Error = new DTO.Common.Error { Message = string.Join("\r\n", root.Errors.Select(x => x.description)) };
            }
            else if (root?.results != null)
            {
                response.List = root.results.Select(ParseProvider).ToList();
            }

            return response;
        }

        private static DTO.NPI.Provider ParseProvider(Parser.Result provider)
        {
            if (provider == null) return null;

            var npiProvider = new DTO.NPI.Provider
            {
                NPI = provider.number,
                Name = provider.basic?.name,
                ProviderName = $"{provider.basic?.last_name}, {provider.basic?.first_name}",
                ProviderFirstName = provider.basic?.first_name,
                ProviderLastName = provider.basic?.last_name,
                OrganizationName = provider.basic?.organization_name,
                ParentOrganizationLegalBusinessName = provider.basic?.parent_organization_legal_business_name,
                Gender = provider.basic?.gender,
                SoleProprietor = provider.basic?.sole_proprietor,
                EnumerationDate = provider.basic?.enumeration_date,
                LastUpdated = provider.basic?.last_updated,
                Status = provider.basic?.status,
                OtherOrganizationName = provider.other_names?.FirstOrDefault()?.organization_name,
                PrimaryTaxonomyCode = provider.taxonomies?.FirstOrDefault(x => x.primary)?.code,
                PrimaryTaxonomyStateLicense = provider.taxonomies?.FirstOrDefault(x => x.primary)?.license,
                PrimaryTaxonomyDescription = provider.taxonomies?.FirstOrDefault(x => x.primary)?.desc,
                PrimaryTaxonomyGroup = provider.taxonomies?.FirstOrDefault(x => x.primary)?.taxonomy_group,
                Identifiers = provider.identifiers?.Select(i => new DTO.NPI.Identifier
                {
                    Code = i.code,
                    Description = i.desc,
                    Issuer = i.issuer,
                    IdentifierValue = i.identifier,
                    State = i.state
                }).ToList(),
                Endpoints = provider.endpoints?.Select(e => new DTO.NPI.Endpoint
                {
                    EndpointType = e.endpointType,
                    EndpointTypeDescription = e.endpointTypeDescription,
                    EndpointValue = e.endpoint,
                    Affiliation = e.affiliation,
                    UseDescription = e.useDescription,
                    ContentTypeDescription = e.contentTypeDescription,
                    CountryCode = e.country_code,
                    CountryName = e.country_name,
                    AddressType = e.address_type,
                    Address1 = e.address_1,
                    City = e.city,
                    State = e.state,
                    PostalCode = e.postal_code
                }).ToList()
            };

            if (provider.addresses?.Count > 0)
            {
                var primaryAddress = provider.addresses[0];
                npiProvider.Address1 = primaryAddress.address_1;
                npiProvider.Address2 = primaryAddress.address_2;
                npiProvider.City = primaryAddress.city;
                npiProvider.State = primaryAddress.state;
                npiProvider.Zip = primaryAddress.postal_code;
                npiProvider.Phone = primaryAddress.telephone_number;
                npiProvider.Fax = primaryAddress.fax_number;
            }

            if (provider.addresses?.Count > 1)
            {
                var mailingAddress = provider.addresses[1];
                npiProvider.MailingAddress1 = mailingAddress.address_1;
                npiProvider.MailingAddress2 = mailingAddress.address_2;
                npiProvider.MailingCity = mailingAddress.city;
                npiProvider.MailingState = mailingAddress.state;
                npiProvider.MailingZip = mailingAddress.postal_code;
                npiProvider.MailingPhone = mailingAddress.telephone_number;
                npiProvider.MailingFax = mailingAddress.fax_number;
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
        public string version => "2.1";

        public string GetSearchParameter()
        {
            var parameters = new List<string>
            {
                $"number={number}",
                $"enumeration_type={enumeration_type}",
                $"taxonomy_description={taxonomy_description}",
                $"name_purpose={name_purpose}",
                $"first_name={first_name}",
                $"use_first_name_alias={use_first_name_alias}",
                $"last_name={last_name}",
                $"organization_name={organization_name}",
                $"address_purpose={address_purpose}",
                $"city={city}",
                $"state={state}",
                $"postal_code={postal_code}",
                $"country_code={country_code}",
                $"limit={limit}",
                $"skip={skip}",
                $"pretty={pretty}",
                $"version={version}"
            };

            return string.Join("&", parameters);
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
