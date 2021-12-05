using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SchoolMomentsApp.Services
{
    public class RestService : IRestService
    {

        private HttpClient httpclient;

        public RestService()
        {
            httpclient = new HttpClient();
        }

        public HttpClient GetHttpClient()
        {
            return httpclient;
        }
    }
}
