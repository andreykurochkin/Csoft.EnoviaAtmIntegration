using Csoft.EnoviaAtmIntegration.Domain.Endpoints;
using System.Net.Http;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// sends Post request to Enovia, keeps result of request
    /// </summary>
    public class ArRequest : IArPostRequest {
        public Ar Ar { get; }
        private HttpClient HttpClient { get; }
        public Task<HttpResponseMessage> TaskResponse { get => taskResponse; }
        private Task<HttpResponseMessage> taskResponse;
        public ArRequest(Ar ear, HttpClient httpClient) {
            Ar = ear;
            HttpClient = httpClient;
        }
        public virtual Task<HttpResponseMessage> PostAsync() {
            HttpClient.DefaultRequestHeaders.Authorization = new EnoviaBasicAuthenticationHeaderValue();
            taskResponse = HttpClient.PostAsync(
                new RemoteIntegrationUri(Ar.EcaId),
                new ArStringContent(Ar)
            );
            return taskResponse;
        }
    }
}