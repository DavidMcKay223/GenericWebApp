using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace GenericWebApp.BLL.Common
{
    public static class ClassExtension
    {
        public static async Task<String> GetUriToJson(this String BaseAddress, String SearchParameter)
        {
            String myJsonResponse = "";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // HTTP GET
                HttpResponseMessage response = await client.GetAsync("?" + SearchParameter);
                if (response.IsSuccessStatusCode)
                {
                    myJsonResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return myJsonResponse;
        }
    }
}
