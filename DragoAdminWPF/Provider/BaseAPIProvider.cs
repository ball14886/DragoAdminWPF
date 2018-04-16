using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DragoAdminWPF.Provider
{
    public class BaseAPIProvider
    {
        public HttpClient client = new HttpClient(new WebRequestHandler()
        {
            CachePolicy =
                new HttpRequestCachePolicy(HttpRequestCacheLevel.NoCacheNoStore)
        });

        public BaseAPIProvider()
        {
            client.BaseAddress = new Uri("http://dragoservices.azurewebsites.net/api/DragoAdmin/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
