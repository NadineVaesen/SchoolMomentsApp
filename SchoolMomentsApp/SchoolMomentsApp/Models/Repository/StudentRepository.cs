using Newtonsoft.Json;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;


namespace SchoolMomentsApp.Models.Repository
{
    public static class StudentRepository
    {
        private static Uri url = Constants.BaseURL;
        private static HttpClient _httpClient = Constants.HttpClient;

        public async static Task<IEnumerable<Student>> GetStudents()
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

        public async static Task<Student> GetStudent(int id)
        {
            
            //Uri fullUrl = new Uri(url + "/students/" + id);
            Uri fullUrl = new Uri(url + "/moments");
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
        public static bool StudentExistsByStudentNumber(string studentnumber)
        {
            return true;
        }


        private static HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }

    }
}
