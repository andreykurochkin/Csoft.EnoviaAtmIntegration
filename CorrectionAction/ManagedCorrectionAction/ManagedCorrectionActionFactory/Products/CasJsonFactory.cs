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
            IConfigurable request =
                new PostHttpRequestMessage(factory);
            return request.Configure();
        }
    }
}