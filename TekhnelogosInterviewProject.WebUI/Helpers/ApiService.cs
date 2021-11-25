using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace TekhnelogosInterviewProject.WebUI.Helpers
{
    
    public class ApiService
    {

        public static string BaseAddress;
        public ApiService(string baseUrl)
        {
            BaseAddress = baseUrl;
        }


    }
}
