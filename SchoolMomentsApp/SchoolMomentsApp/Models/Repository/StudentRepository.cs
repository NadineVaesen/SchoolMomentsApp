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
    public class StudentRepository : IStudentRepository
    {
        private Uri url = Constants.BaseURL;
        private HttpClient _httpClient;


        public StudentRepository(IRestService restService)
        {
            _httpClient = restService.GetHttpClient();
        }

        public async Task<IEnumerable<Student>> GetStudents()
        {

            Uri fullUrl = new Uri(url + "/students");


            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();

                IEnumerable<Student> students = JsonConvert.DeserializeObject<IEnumerable<Student>>(content);
                return students;
            }
            return null;
        }

        public async Task<Student> GetStudent(int id)
        {

            //Uri fullUrl = new Uri(url + "/students/" + id);
            Uri fullUrl = new Uri(url + "/students/" + id);
            var options = new JsonSerializerSettings { };


            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Student student = JsonConvert.DeserializeObject<Student>(content);
                return student;
            }
            return null;
        }
        public bool StudentExistsByStudentNumber(string studentnumber)
        {
            return true;
        }



    }
}
