using Newtonsoft.Json;
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
        //TODO: Change this into a DTO { List Provider, String Error }
        public static async Task<List<DTO.NPI.Provider>> GetProviderList(RegistrySearchDTO searchDTO)
        {
            String myJsonResponse = await "https://npiregistry.cms.hhs.gov/api/".GetUriToJson(searchDTO.GetSearchParameter());

            GenericWebApp.BLL.NPI.Parser.Root? myRoot = JsonConvert.DeserializeObject<GenericWebApp.BLL.NPI.Parser.Root>(myJsonResponse);

            //TODO: Not throwing Exception for Future it will be in DTO.Error
            if (myRoot != null && myRoot.Errors != null && myRoot.Errors.Count > 0)
            {
                throw new Exception(String.Join("\r\n", myRoot.Errors.Select(x => x.description)));
            }
            else if (myRoot != null && myRoot.results != null && myRoot.results.Count > 0)
            {
                List<DTO.NPI.Provider> providerList = new List<DTO.NPI.Provider>();

                foreach(Parser.Result myProvider in myRoot.results)
                {
                    //Rough Idea: Extract into a function
                    providerList.Add(new DTO.NPI.Provider()
                    {
                        NPI = myProvider.number,
                        ProviderName = String.Join(", ", myProvider.basic.first_name, myProvider.basic.last_name)
                    });
                }

                return providerList;
            }

            return new List<DTO.NPI.Provider>();
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
