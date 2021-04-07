using Csoft.EnoviaAtmIntegration.Domain.Http;
using System.Net.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class EnoviaHttpClient : CsoftHttpClient {
        HttpRequestMessage httpRequestMessage = null;
        readonly IPostHttpRequestMessageFactory httpRequestMessageFactory =
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