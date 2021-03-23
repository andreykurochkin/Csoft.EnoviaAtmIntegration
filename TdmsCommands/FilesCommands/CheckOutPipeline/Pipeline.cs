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
    /// encapsulate algoritm to process TInput -> TOutput
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public abstract class Pipeline<TInput, TOutput> : IPipelineStep<TInput, TOutput> {
        public Func<TInput, TOutput> PipelineSteps { get; protected set; }
        public TOutput Process(TInput input) {
            return PipelineSteps(input);
        }
    }
}
