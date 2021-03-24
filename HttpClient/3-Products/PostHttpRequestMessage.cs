using System.Net.Http;

namespace Csoft.EnoviaAtmIntegration.Domain.Http {
    public class PostHttpRequestMessage : HttpRequestMessage {
        public PostHttpRequestMessage(IPostHttpRequestMessageFactory factory) {
            Configure(factory);
        }
        private void Configure(IPostHttpRequestMessageFactory factory) {
            RequestUri = factory.CreateUri();
            Method = factory.CreateHttpMethod();
            Headers.Add("Authorization", factory.CreateAuthorization()
                .ToString());
            Content = factory.CreateStringContent();
            Headers.Add("Accept", "application/json");
        }
    }
}