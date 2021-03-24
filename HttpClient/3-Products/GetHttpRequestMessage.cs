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
    public class GetHttpRequestMessage : HttpRequestMessage {
        private IGetHttpRequestMessageFactory factory;
        public GetHttpRequestMessage(IGetHttpRequestMessageFactory factory) {
            this.factory = factory;
        }
        public HttpRequestMessage Configure() {
            this.RequestUri = factory.CreateUri();
            this.Method = factory.CreateHttpMethod();
            this.Headers.Add(
                "Authorization",
                factory.CreateAuthorization().ToString());
            return this;
        }
    }
}