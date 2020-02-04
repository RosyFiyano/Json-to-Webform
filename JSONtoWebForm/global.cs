using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;

namespace JSONtoWebForm
{
    public static class global
    {
        public static HttpClient webclient=new HttpClient();

        static global()
        {
            webclient.BaseAddress = new Uri("http://localhost:8609/api/jsondatatbls");
            webclient.DefaultRequestHeaders.Clear();
            webclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
   
}