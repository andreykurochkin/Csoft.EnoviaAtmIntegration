using System.Net.Http;
using Csoft.EnoviaAtmIntegration.Domain.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {

    /// <summary>
    /// fetches json from Enovia
    /// </summary>
    public class EcasJson : CasJson {
        public EcasJson() {
            SetHttpClient(
                new BaseHttpClient(
                    new PostHttpRequestMessage(
                        new AllEcaRequestFactory()
                    ), 
                    new HttpClient()
            ));
        }
    }

    public abstract class CasJson {
        protected IHttpRequestDispatch HttpClient { get; set; }
        internal void SetHttpClient(IHttpRequestDispatch httpClient) {
            HttpClient = httpClient;
        }
        public override string ToString() {
            return HttpClient.SendRequest().Result
                .Content.ReadAsStringAsync().Result;
        }
    }


    /// <summary>
    /// creates ICas items
    /// </summary>
    public class CasJsonFactory {
        public static string CreateEcasAsJson() {
            IHttpRequestDispatch client = new BaseHttpClient(
                new PostHttpRequestMessage(new AllEcaRequestFactory()),
                new HttpClient()
            );
            var task = client.SendRequest().Result
                .Content.ReadAsStringAsync();
            return task.Result;
        }
        public static string CreateNoSentToTdmsEcasAsJson() {
            IHttpRequestDispatch client = 
                new BaseHttpClient(
                    new PostHttpRequestMessage(
                        new NoSentToTdmsRequestFactory(
                            new AllEcaRequestFactory()
                        )
                    ),
                   new HttpClient()
                );
            return client.SendRequest().Result
                .Content.ReadAsStringAsync().Result;
        }
    }
}