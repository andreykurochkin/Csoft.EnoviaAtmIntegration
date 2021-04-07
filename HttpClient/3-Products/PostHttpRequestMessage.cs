using System.Net.Http;
using Csoft.EnoviaAtmIntegration.Domain;

namespace Csoft.EnoviaAtmIntegration.Domain.Http {
    /// <summary>
    /// configures HttpRequestMessage via factory
    /// </summary>
    public class PostHttpRequestMessage : HttpRequestMessage {
        protected IPostHttpRequestMessageFactory Factory { get; }
        public PostHttpRequestMessage(IPostHttpRequestMessageFactory factory) {
            Factory = factory;
            Configure();
        }
        internal void Configure() {
            RequestUri = Factory.CreateUri();
            Method = Factory.CreateHttpMethod();
            Headers.Add("Authorization", Factory.CreateAuthorization()
                .ToString());
            Content = Factory.CreateStringContent();
            Headers.Add("Accept", "application/json");
        }
    }
}