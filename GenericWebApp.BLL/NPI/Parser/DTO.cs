using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.BLL.NPI.Parser
{
    internal class Address
    {
        public string? Country_code { get; set; }
        public string? Country_name { get; set; }
        public string? Address_purpose { get; set; }
        public string? Address_type { get; set; }
        public string? Address_1 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal_code { get; set; }
        public string? Telephone_number { get; set; }
        public string? Fax_number { get; set; }
        public string? Address_2 { get; set; }
    }

    internal class Basic
    {
        public string? Organization_name { get; set; }
        public string? Organizational_subpart { get; set; }
        public string? Enumeration_date { get; set; }
        public string? Last_updated { get; set; }
        public string? Certification_date { get; set; }
        public string? Status { get; set; }
        public string? Authorized_official_first_name { get; set; }
        public string? Authorized_official_last_name { get; set; }
        public string? Authorized_official_telephone_number { get; set; }
        public string? Authorized_official_title_or_position { get; set; }
        public string? Authorized_official_name_prefix { get; set; }
        public string? Authorized_official_name_suffix { get; set; }
        public string? Authorized_official_credential { get; set; }
        public string? Authorized_official_middle_name { get; set; }
        public string? First_name { get; set; }
        public string? Last_name { get; set; }
        public string? Middle_name { get; set; }
        public string? Sole_proprietor { get; set; }
        public string? Gender { get; set; }
        public string? Name_prefix { get; set; }
        public string? Parent_organization_legal_business_name { get; internal set; }
        public string? Name { get; internal set; }
    }

    internal class Endpoint
    {
        public string? EndpointType { get; set; }
        public string? EndpointTypeDescription { get; set; }
        public string? endpoint { get; set; }
        public string? Affiliation { get; set; }
        public string? UseDescription { get; set; }
        public string? ContentTypeDescription { get; set; }
        public string? Country_code { get; set; }
        public string? Country_name { get; set; }
        public string? Address_type { get; set; }
        public string? Address_1 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal_code { get; set; }
    }

    internal class Identifier
    {
        public string? Code { get; set; }
        public string? Desc { get; set; }
        public string? Issuer { get; set; }
        public string? identifier { get; set; }
        public string? State { get; set; }
    }

    internal class OtherName
    {
        public string? Organization_name { get; set; }
        public string? Type { get; set; }
        public string? Code { get; set; }
    }

    internal class PracticeLocation
    {
        public string? Country_code { get; set; }
        public string? Country_name { get; set; }
        public string? Address_purpose { get; set; }
        public string? Address_type { get; set; }
        public string? Address_1 { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Postal_code { get; set; }
        public string? Telephone_number { get; set; }
        public string? Fax_number { get; set; }
    }

    internal class Result
    {
        public string? Created_epoch { get; set; }
        public string? Enumeration_type { get; set; }
        public string? Last_updated_epoch { get; set; }
        public string? Number { get; set; }
        public List<Address>? Addresses { get; set; }
        public List<PracticeLocation>? PracticeLocations { get; set; }
        public Basic? Basic { get; set; }
        public List<Taxonomy>? Taxonomies { get; set; }
        public List<Identifier>? Identifiers { get; set; }
        public List<Endpoint>? Endpoints { get; set; }
        public List<OtherName>? Other_names { get; set; }
    }

    public class Error
    {
        public string? Description { get; set; }
        public string? Field { get; set; }
        public string? Number { get; set; }
    }

    internal class Root
    {
        public int Result_count { get; set; }
        public List<Result>? Results { get; set; }
        public List<Error>? Errors { get; set; }
    }

    internal class Taxonomy
    {
        public string? Code { get; set; }
        public string? Taxonomy_group { get; set; }
        public string? Desc { get; set; }
        public string? State { get; set; }
        public string? License { get; set; }
        public bool Primary { get; set; }
    }
}
