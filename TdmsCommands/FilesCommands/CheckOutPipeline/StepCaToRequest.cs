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
    /// creates HttpRequestMessage from Eca
    /// </summary>
    internal class StepCaToRequest : IPipelineStep<ICa, HttpRequestMessage> {
        public HttpRequestMessage Process(ICa input) {
            return new GetHttpRequestMessage(
                new CheckOutFileRequestFactory(input)
            )
            .Configure();
        }
    }
}
