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
    /// invokes HttpContent from Task<HttpResponseMessage>
    /// </summary>
    internal class StepTaskResponseToContent
        : IPipelineStep<Task<HttpResponseMessage>, HttpContent> {
        public HttpContent Process(Task<HttpResponseMessage> input) {
            return input.Result.Content;
        }
    }
}
