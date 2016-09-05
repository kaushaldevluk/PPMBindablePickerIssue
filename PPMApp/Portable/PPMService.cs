using Portable.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portable
{
    public class PPMService
    {
        IRestService restService;
        
        public PPMService(RestService restService)
        {
            this.restService = restService;
        }

        public Task DownloadData()
        {
            return restService.DownloadData();
        }

        public Task UploadData()
        {
            return restService.UploadData();
        }

    }
}
