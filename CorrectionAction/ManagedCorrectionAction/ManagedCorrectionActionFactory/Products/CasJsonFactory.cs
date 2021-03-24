using System.Net.Http;
using Csoft.EnoviaAtmIntegration.Domain.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {

    /// <summary>
    /// fetches json from Enovia
    /// </summary>
    public class EcasJson {
        private HttpClient HttpClient { get; }
        private HttpRequestMessage HttpRequestMessage { get; }
        public EcasJson() {
            HttpClient = new();
            HttpRequestMessage = new PostHttpRequestMessage(
                new AllEcaRequestFactory()
            );
        }
        public override string ToString() {
            return HttpClient.SendAsync(HttpRequestMessage).Result.Content.ReadAsStringAsync().Result;
        }
    }
    /// <summary>
    /// fetches json from Enovia
    /// </summary>
    internal class NoSentToTdmsEcasJson : JsonDispatch {
        protected override HttpRequestMessage HttpRequestMessage { get; } = 
            new PostHttpRequestMessage(
                new NoSentToTdmsRequestFactory(
                    new AllEcaRequestFactory()
                )
            );
    }

    internal abstract class JsonDispatch {
        protected HttpClient HttpClient { get; } = new();
        protected virtual HttpRequestMessage HttpRequestMessage { get; }
        public override string ToString() {
            return HttpClient.SendAsync(HttpRequestMessage).Result.Content.ReadAsStringAsync().Result;
        }
    }

    //public abstract class CasJson {
    //    protected IHttpRequestDispatch HttpClient { get; set; }
    //    internal void SetHttpClient(IHttpRequestDispatch httpClient) {
    //        HttpClient = httpClient;
    //    }
    //    public override string ToString() {
    //        return HttpClient.SendRequest().Result
    //            .Content.ReadAsStringAsync().Result;
    //    }
    //}


    /// <summary>
    /// creates ICas items
    /// </summary>
    public class CasJsonFactory {
        public static string CreateEcasAsJson() {
            using (HttpClient httpClient = new()) {
                var request = new PostHttpRequestMessage(
                    new AllEcaRequestFactory()
                );
                var response = httpClient.SendAsync(request);
                var json = response.Result.Content.ReadAsStringAsync();
                return json.Result;
            }
        }
        public static string CreateNoSentToTdmsEcasAsJson() {
            using (HttpClient httpClient = new()) {
                var request = new PostHttpRequestMessage(
                    new NoSentToTdmsRequestFactory(
                        new AllEcaRequestFactory()
                    )
                );
                var response = httpClient.SendAsync(request);
                var json = response.Result.Content.ReadAsStringAsync();
                return json.Result;
            }
        }
    }
}