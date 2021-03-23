using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class PostHttpRequestMessage 
        : HttpRequestMessage, IConfigurable
    {
        private IPostHttpRequestMessageFactory requestFactory;

        public PostHttpRequestMessage(
            IPostHttpRequestMessageFactory httpRequestMessageFactory)
        {
            this.requestFactory = httpRequestMessageFactory;
        }

        public HttpRequestMessage Configure()
        {
            this.RequestUri = requestFactory.CreateUri();
            this.Method = requestFactory.CreateHttpMethod();
            this.Headers.Add("Authorization", 
                requestFactory.CreateAuthorization().ToString());
            this.Content = requestFactory.CreateStringContent();

            this.Headers.Add("Accept", "application/json");

            return this;
        }
    }
}