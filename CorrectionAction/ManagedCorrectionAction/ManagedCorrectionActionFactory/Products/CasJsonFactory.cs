using System.Net.Http;
using Csoft.EnoviaAtmIntegration.Domain.Http;

namespace Csoft.EnoviaAtmIntegration.Domain {
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