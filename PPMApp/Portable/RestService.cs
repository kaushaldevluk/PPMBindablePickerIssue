using Portable.Controller;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Portable
{
    public class RestService : IRestService
    {
        HttpClient client;
        public RestService()
        {

            //var authHeaderValue = Convert.ToBase64String(Encoding.UTF8.GetBytes(authData));

            client = new HttpClient();
            client.MaxResponseContentBufferSize = 256000;

        }

        public Task DownloadData()
        {
            throw new NotImplementedException();
        }

        public Task UploadData()
        {
            throw new NotImplementedException();
        }
    }
}
