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

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class ServiceEnoviaHttpClient 
        : EnoviaHttpClient
    {
        private IPostHttpRequestMessageFactory factory;

        public ServiceEnoviaHttpClient(
            IPostHttpRequestMessageFactory factory)
        {
            this.factory = factory;
        }
        
        internal override HttpRequestMessage CreateHttpRequestMessage(
            string format)
        {
            var requestMessage = 
                new PostHttpRequestMessage(factory);
            requestMessage.Configure();
            return requestMessage;
        }
    }
}