using Newtonsoft.Json;
using SchoolMomentsApp.Services;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public class MomentRepository : IMomentRepository
    {
        
        private IRestService _restService;
        private HttpClient _httpClient;
        private Uri url = Constants.BaseURL;

        public MomentRepository(IRestService restService)
        {
            _restService = restService;
        }

        public async Task<IEnumerable<Moment>> GetMomentsAsync()
        {
            _httpClient = _restService.GetHttpClient();

            Uri fullUrl = new Uri(url + "/moments");

            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Moment> moments = JsonConvert.DeserializeObject<IEnumerable<Moment>>(content);

                return moments;
            }
            return null;

        }

        public async Task<Moment> GetMoment(int id)
        {

            HttpClient httpClient = _httpClient;
            Uri fullUrl = new Uri(url + "/moments/" + id);
            var options = new JsonSerializerSettings { };


            HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Moment moment = JsonConvert.DeserializeObject<Moment>(content);
                return moment;
            }
            return null;
        }

        public async Task<Moment> AddRequestedStudent(int id, Moment moment)
        {
            HttpClient httpClient = _httpClient;
            Uri fullUrl = new Uri(url + "moments/" + id);
            var options = new JsonSerializerSettings { };


            var content = new StringContent(JsonConvert.SerializeObject(moment));


            HttpResponseMessage response = await httpClient.PutAsync(fullUrl.ToString(), content);
            if (response.IsSuccessStatusCode)
            {
                return moment;
            }
            return null;


        }

        private HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }
    }
}
