using Newtonsoft.Json;
using GenericWebApp.BLL.Common;

namespace GenericWebApp.BLL.NPI
{
    public class Registry
    {
        private const string Endpoint = "https://npiregistry.cms.hhs.gov/api/";

        public static async Task<DTO.Common.Response<DTO.NPI.Provider>> GetProviderList(RegistrySearchDTO searchDTO = null)
        {
            var response = new DTO.Common.Response<DTO.NPI.Provider>() { ErrorList = [] };

            if (searchDTO == null) return response;

            var jsonResponse = await Endpoint.GetUriToJson(searchDTO.GetSearchParameter());
            var root = JsonConvert.DeserializeObject<Parser.Root>(jsonResponse);

            if (root?.Errors?.Count > 0)
            {
                response.ErrorList = [];

                root.Errors.ForEach(x => response.ErrorList.Add(new DTO.Common.Error() { Message = x.Description }));
            }
            else if (root?.Results != null)
            {
                response.List = root.Results.ConvertAll(ParseProvider);
            }

            return response;
        }

        private static DTO.NPI.Provider ParseProvider(Parser.Result provider)
        {
            if (provider == null) return null;

            var npiProvider = new DTO.NPI.Provider
            {
                NPI = provider.Number,
                Name = provider.Basic?.Name,
                ProviderName = $"{provider.Basic?.Last_name}, {provider.Basic?.First_name}",
                ProviderFirstName = provider.Basic?.First_name,
                ProviderLastName = provider.Basic?.Last_name,
                OrganizationName = provider.Basic?.Organization_name,
                ParentOrganizationLegalBusinessName = provider.Basic?.Parent_organization_legal_business_name,
                Gender = provider.Basic?.Gender,
                SoleProprietor = provider.Basic?.Sole_proprietor,
                EnumerationDate = provider.Basic?.Enumeration_date,
                LastUpdated = provider.Basic?.Last_updated,
                Status = provider.Basic?.Status,
                OtherOrganizationName = provider.Other_names?.FirstOrDefault()?.Organization_name,
                PrimaryTaxonomyCode = provider.Taxonomies?.FirstOrDefault(x => x.Primary)?.Code,
                PrimaryTaxonomyStateLicense = provider.Taxonomies?.FirstOrDefault(x => x.Primary)?.License,
                PrimaryTaxonomyDescription = provider.Taxonomies?.FirstOrDefault(x => x.Primary)?.Desc,
                PrimaryTaxonomyGroup = provider.Taxonomies?.FirstOrDefault(x => x.Primary)?.Taxonomy_group,
                Identifiers = provider.Identifiers?.Select(i => new DTO.NPI.Identifier
                {
                    Code = i.Code,
                    Description = i.Desc,
                    Issuer = i.Issuer,
                    IdentifierValue = i.identifier,
                    State = i.State
                }).ToList(),
                Endpoints = provider.Endpoints?.Select(e => new DTO.NPI.Endpoint
                {
                    EndpointType = e.EndpointType,
                    EndpointTypeDescription = e.EndpointTypeDescription,
                    EndpointValue = e.endpoint,
                    Affiliation = e.Affiliation,
                    UseDescription = e.UseDescription,
                    ContentTypeDescription = e.ContentTypeDescription,
                    CountryCode = e.Country_code,
                    CountryName = e.Country_name,
                    AddressType = e.Address_type,
                    Address1 = e.Address_1,
                    City = e.City,
                    State = e.State,
                    PostalCode = e.Postal_code
                }).ToList()
            };

            if (provider.Addresses?.Count > 0)
            {
                var primaryAddress = provider.Addresses[0];
                npiProvider.Address1 = primaryAddress.Address_1;
                npiProvider.Address2 = primaryAddress.Address_2;
                npiProvider.City = primaryAddress.City;
                npiProvider.State = primaryAddress.State;
                npiProvider.Zip = primaryAddress.Postal_code;
                npiProvider.Phone = primaryAddress.Telephone_number;
                npiProvider.Fax = primaryAddress.Fax_number;
            }

            if (provider.Addresses?.Count > 1)
            {
                var mailingAddress = provider.Addresses[1];
                npiProvider.MailingAddress1 = mailingAddress.Address_1;
                npiProvider.MailingAddress2 = mailingAddress.Address_2;
                npiProvider.MailingCity = mailingAddress.City;
                npiProvider.MailingState = mailingAddress.State;
                npiProvider.MailingZip = mailingAddress.Postal_code;
                npiProvider.MailingPhone = mailingAddress.Telephone_number;
                npiProvider.MailingFax = mailingAddress.Fax_number;
            }

            return npiProvider;
        }
    }

    public class RegistrySearchDTO
    {
        public string? Number { get; set; }
        public string? Enumeration_type { get; set; }
        public string? Taxonomy_description { get; set; }
        public string? Name_purpose { get; set; }
        public string? First_name { get; set; }
        public string? Use_first_name_alias { get; set; }
        public string? Last_name { get; set; }
        public string? Organization_name { get; set; }
        public string? Address_purpose { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal_code { get; set; }
        public string? Country_code { get; set; }
        public string? Limit { get; set; }
        public string? Skip { get; set; }
        public string? Pretty { get; set; }
        public static string Version => "2.1";

        public string GetSearchParameter()
        {
            var parameters = new List<string>
            {
                $"number={Number}",
                $"enumeration_type={Enumeration_type}",
                $"taxonomy_description={Taxonomy_description}",
                $"name_purpose={Name_purpose}",
                $"first_name={First_name}",
                $"use_first_name_alias={Use_first_name_alias}",
                $"last_name={Last_name}",
                $"organization_name={Organization_name}",
                $"address_purpose={Address_purpose}",
                $"city={City}",
                $"state={State}",
                $"postal_code={Postal_code}",
                $"country_code={Country_code}",
                $"limit={Limit}",
                $"skip={Skip}",
                $"pretty={Pretty}",
                $"version={Version}"
            };

            return string.Join("&", parameters);
        }
    }
}
