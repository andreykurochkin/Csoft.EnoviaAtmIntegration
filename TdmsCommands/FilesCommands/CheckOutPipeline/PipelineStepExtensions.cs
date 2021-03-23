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
    /// extension to move from one step to another stop of pipeline
    /// </summary>
    public static class PipelineStepExtensions {
        public static TOutput Step<TInput, TOutput>(this TInput input,
                                                    IPipelineStep<TInput, TOutput> step) {
            return step.Process(input);
        }
    }
}
