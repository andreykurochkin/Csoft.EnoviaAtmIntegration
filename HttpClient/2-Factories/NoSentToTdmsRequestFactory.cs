using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Csoft.EnoviaAtmIntegration.Domain.Requests;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// configures HttpRequestMessage in order to
    /// fetch from Enovia 
    /// correction actions with empty SentToTdmsDate
    /// </summary>
    public class NoSentToTdmsRequestFactory : IPostHttpRequestMessageFactory {
        public IPostHttpRequestMessageFactory Origin { get; }
        public NoSentToTdmsRequestFactory(IPostHttpRequestMessageFactory origin) {
            Origin = origin;
        }
        public AuthenticationHeaderValue CreateAuthorization() {
            return Origin.CreateAuthorization();
        }

        public HttpContent CreateStringContent() {
            return new StringContent(
                new NoSentToTdmsDateSearchCorrectionActionsCreatedAfterOriginatedDateAndWihinKulamBodyContent().ToString(),
                Encoding.UTF8,
                "application/json");
        }
        public HttpMethod CreateHttpMethod() {
            return Origin.CreateHttpMethod();
        }
        public Uri CreateUri() {
            return Origin.CreateUri();
        }
    }
}
