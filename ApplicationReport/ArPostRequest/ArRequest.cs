using System.Net.Http;
namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// creates Post request to Enovia
    /// </summary>
    public class ArRequest : IArPostRequest {
        private readonly Ar ar;
        private HttpResponseMessage response;

        public ArRequest(Ar ear) {
            this.ar = ear;
        }
        public Ar Ar => ar;
        public HttpResponseMessage Response => response;

        public virtual HttpResponseMessage PostAsync() {
            using (var c = new HttpClient()) {
                c.DefaultRequestHeaders.Authorization =
                    new EnoviaBasicAuthenticationHeaderValue();

                response = c.PostAsync(
                    new Endpoints.RemoteIntegrationUri(ar.EcaId),
                    new ArStringContent(ar))
                    .Result;

                return response;
            }
        }
    }
}