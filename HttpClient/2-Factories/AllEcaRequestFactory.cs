using Csoft.EnoviaAtmIntegration.Domain.Requests;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class AllEcaRequestFactory : IPostHttpRequestMessageFactory {
        public virtual AuthenticationHeaderValue CreateAuthorization() {
            return new EnoviaBasicAuthenticationHeaderValue();
        }
        public virtual HttpMethod CreateHttpMethod() {
            return HttpMethod.Post;
        }
        public virtual Uri CreateUri() {
            return new Endpoints.SearchUri();
        }
        public virtual HttpContent CreateStringContent() {
            return new StringContent(
                new CorrectionActionsCreatedAfterOriginatedDateAndWihinKulamBodyContent().ToString(),
                Encoding.UTF8, "application/json");
        }
    }
}