using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace SchoolMomentsApp.Services
{
    public interface IRestService
    {

        HttpClient GetHttpClient();
    }
}
