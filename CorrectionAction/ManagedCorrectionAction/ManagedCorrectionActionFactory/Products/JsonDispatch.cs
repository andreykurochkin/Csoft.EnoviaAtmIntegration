using System.Net.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// its implementations fetche json from Enovia
    /// </summary>
    internal abstract class JsonDispatch {
        protected HttpClient HttpClient { get; } = new();
        internal protected abstract HttpRequestMessage HttpRequestMessage { get; }
        public override string ToString() {
            return HttpClient.SendAsync(HttpRequestMessage)
                .Result.Content.ReadAsStringAsync().Result;
        }
    }
}