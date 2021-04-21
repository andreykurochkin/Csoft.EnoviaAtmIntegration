using Csoft.EnoviaAtmIntegration.Domain.Endpoints;
using System.Net.Http;
namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// creates Post request to Enovia
    /// </summary>
    public class ArRequest : IArPostRequest {
        public Ar Ar { get; }
        private HttpClient HttpClient { get; }
        public ArRequest(Ar ear, HttpClient httpClient) {
            Ar = ear;
            HttpClient = httpClient;
        }
        public virtual HttpResponseMessage PostAsync() {
            HttpClient.DefaultRequestHeaders.Authorization = new EnoviaBasicAuthenticationHeaderValue();
            var response = HttpClient.PostAsync(
                new RemoteIntegrationUri(Ar.EcaId),
                new ArStringContent(Ar)
            );
            return response.Result;
        }
    }
}