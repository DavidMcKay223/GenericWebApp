using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericWebApp.DTO.NPI
{
    public class RegistryResponse
    {
        public List<Provider> ProviderList { get; set; }
        public Error Error { get; set; }
    }

    public class Provider
    {
        public string NPI { get; set; }
        public string ProviderFirstName { get; set; }
        public string ProviderLastName { get; set; }
        public string OrganizationName { get; set; }
    }

    public class Error
    {
        public string Message { get; set; }
    }
}
