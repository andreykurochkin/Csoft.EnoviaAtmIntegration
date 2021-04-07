using Csoft.EnoviaAtmIntegration.Domain.Http;
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
    public class ServiceEnoviaHttpClient : EnoviaHttpClient {
        private IPostHttpRequestMessageFactory Factory { get; }
        public ServiceEnoviaHttpClient(IPostHttpRequestMessageFactory factory) {
            Factory = factory;
        }
        internal override HttpRequestMessage CreateHttpRequestMessage(string format) {
            PostHttpRequestMessage requestMessage = new(Factory);
            requestMessage.Configure();
            return requestMessage;
        }
    }
}