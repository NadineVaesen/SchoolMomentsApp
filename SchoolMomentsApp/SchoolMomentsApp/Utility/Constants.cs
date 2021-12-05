using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SchoolMomentsApp.Utility
{
    public static class Constants
    {
        public static HttpClient HttpClient = new HttpClient();
        public static Uri BaseURL = new Uri("http://10.0.2.2:49630/api");

        private static HttpClient InitializeHttpClient()
        {
            return HttpClient ?? new HttpClient();
        }
    }
}
