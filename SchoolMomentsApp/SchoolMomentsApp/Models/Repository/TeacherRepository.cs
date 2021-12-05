using Newtonsoft.Json;
using SchoolMomentsApp.Utility;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SchoolMomentsApp.Models.Repository
{
    public static class TeacherRepository
    {

        private static Uri url = Constants.BaseURL;
        private static HttpClient _httpClient = Constants.HttpClient;

        private static IEnumerable<Teacher> teachers;
        public async static Task<IEnumerable<Teacher>> GetTeachers()
        {
   
            Uri fullUrl = new Uri(url + "/teachers");


            HttpResponseMessage response = await _httpClient.GetAsync(fullUrl);


            if (response.IsSuccessStatusCode)
            {

                string content = await response.Content.ReadAsStringAsync();

                teachers = JsonConvert.DeserializeObject<IEnumerable<Teacher>>(content);
                return teachers;
            }
            return null;
        }

        public async static Task<Teacher> GetTeacher(int id)
        {
            HttpClient httpClient = _httpClient;
            Uri fullUrl = new Uri(url + "/teachers/" + id);
            var options = new JsonSerializerSettings { };


            HttpResponseMessage response = await httpClient.GetAsync(fullUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                Teacher teacher = JsonConvert.DeserializeObject<Teacher>(content);
                return teacher;
            }
            return null;
        }

        public static bool TeacherExistsByTeacherNumber(string teachernumber)
        {
            foreach(var teacher in teachers)
            {
                if(teacher.TeacherNumber == teachernumber)
                {
                    return true;
                }
            }
            return false;
        }

        private static HttpClient InitializeHttpClient()
        {
            return _httpClient ?? new HttpClient();
        }
    }
}
