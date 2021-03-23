using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class CheckOutFileRequestFactory : IGetHttpRequestMessageFactory {
        public CheckOutFileRequestFactory(ICa eca) {
            Eca = eca;
        }
        public ICa Eca { get ; }
        public AuthenticationHeaderValue CreateAuthorization() {
            return new EnoviaBasicAuthenticationHeaderValue();
        }
        public HttpMethod CreateHttpMethod() {
            return HttpMethod.Get;
        }
        public Uri CreateUri() {
            return new Endpoints.CheckoutUri(Eca.Id);
        }
    }
}
