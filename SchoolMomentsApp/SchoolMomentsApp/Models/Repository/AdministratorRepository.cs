using Newtonsoft.Json;
using SchoolMomentsApp.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public class AdministratorRepository : IAdministratorRepository
    {
        private HttpClient _httpClient;

        private Uri BaseUrl = new Uri("http://10.0.2.2:49630/api");

        public AdministratorRepository(IRestService restService)
        {
            _httpClient = restService.GetHttpClient();
        }

        public async Task<IEnumerable<Administrator>> GetAdministrators()
        {

            Uri fullUrl = new Uri(BaseUrl + "/administrators");


            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<Administrator> admins = JsonConvert.DeserializeObject<IEnumerable<Administrator>>(content);
                return admins;
            }
            return null;
        }

        public Administrator GetAdministrator()
        {
            return new Administrator();
        }
        public bool AdministratorExistByAdminNumber(string AdminNumber)
        {
            return true;
        }


    }
}
