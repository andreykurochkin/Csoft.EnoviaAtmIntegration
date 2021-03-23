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

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class EnoviaHttpClient : CsoftHttpClient {
        HttpRequestMessage httpRequestMessage = null;
        IPostHttpRequestMessageFactory httpRequestMessageFactory =
            new AllEcaRequestFactory();
        internal override HttpRequestMessage
            CreateHttpRequestMessage(string format) {
            if (format.Equals("json")) {
                var requestMessage =
                    new PostHttpRequestMessage(
                        httpRequestMessageFactory);
                requestMessage.Configure();
                httpRequestMessage = requestMessage;
            }

            return httpRequestMessage;
        }
    }
}