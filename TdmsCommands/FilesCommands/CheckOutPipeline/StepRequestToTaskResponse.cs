using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    ///  creates Task<HttpResponseMessage> from HttpRequestMessage
    /// </summary>
    internal class StepRequestToTaskResponse
        : IPipelineStep<HttpRequestMessage, Task<HttpResponseMessage>> {
        private HttpClient HttpClient { get; }
        internal StepRequestToTaskResponse(HttpClient httpClient) {
            HttpClient = httpClient;
        }
        public Task<HttpResponseMessage> Process(HttpRequestMessage input) {
            HttpClient.Send(input);
        }
    }
}
