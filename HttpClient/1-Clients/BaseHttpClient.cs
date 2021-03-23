using System.Net.Http;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class BaseHttpClient : IHttpRequestDispatch {
        HttpRequestMessage request;
        public HttpClient Client { get ; }
        public BaseHttpClient(HttpRequestMessage request, HttpClient httpClient) {
            this.request = request;
            Client = httpClient;
        }
        public Task<HttpResponseMessage> SendRequest() {
            return Client.SendAsync(request);
        }
    }
}