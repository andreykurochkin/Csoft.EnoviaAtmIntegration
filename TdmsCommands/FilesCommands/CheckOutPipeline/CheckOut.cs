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
    /// encapsulates algorithm to checkout file from Enovia and checkin to Tdms
    /// </summary>
    internal class CheckOut : Pipeline<ICa, IEnumerable<TDMSFile>> {
        private HttpClient HttpClient { get; }
        private DirectoryInfo Folder { get; }
        private CachedActiveVersions Cache { get; }
        private TDMSApplication App { get; }
        internal CheckOut(HttpClient httpClient,
                        DirectoryInfo folder,
                        CachedActiveVersions cache,
                        TDMSApplication app) {
            HttpClient = httpClient;
            Folder = folder;
            Cache = cache;
            App = app;

            PipelineSteps = input => input
                .Step(new StepCaToRequest())
                .Step(new StepRequestToTaskResponse(HttpClient))
                .Step(new StepTaskResponseToContent())
                .Step(new StepContentToZipFile(Folder))
                .Step(new StepZipFileToFiles(Folder))
                .Step(
                    new StepCheckInToTdmsLogged(
                        App.GetObjectsByGUIDs(Cache, input.Id)
                    )
                );
        }
    }
}
