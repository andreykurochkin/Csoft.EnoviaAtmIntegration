using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
                    ).Configure(), 
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
                CreateRequest(new AllEcaRequestFactory()),
                new HttpClient()
            );
            var task = client.SendRequest().Result
                .Content.ReadAsStringAsync();
            return task.Result;
        }
        public static string CreateNoSentToTdmsEcasAsJson() {
            IHttpRequestDispatch client = 
                new BaseHttpClient(
                    CreateRequest(
                        new NoSentToTdmsRequestFactory(
                            new AllEcaRequestFactory()
                        )
                    ),
                   new HttpClient()
                );
            return client.SendRequest().Result
                .Content.ReadAsStringAsync().Result;
        }
        private static HttpRequestMessage CreateRequest(
            IPostHttpRequestMessageFactory factory) {
            IConfigurable request = new PostHttpRequestMessage(factory);
            return request.Configure();
        }
    }
}