using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class PutHttpClient : IHttpRequestDispatch
    {
        private HttpClient httpClient = new HttpClient();
        private IPutHttpRequestMessageFactory factory;

        public PutHttpClient(
            IPutHttpRequestMessageFactory factory)
        {
            this.factory = factory;
        }

        public Task<HttpResponseMessage> SendRequest()
        {
            httpClient.DefaultRequestHeaders.Authorization =
                factory.CreateAuthenticationHeaderValue();

            var task = httpClient.PutAsync(
                factory.CreateUri(),
                factory.CreateStringContent());
            return task;
        }
    }
}