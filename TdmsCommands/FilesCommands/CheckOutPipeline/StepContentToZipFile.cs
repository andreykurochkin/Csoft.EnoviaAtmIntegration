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
    /// checks out zip file from HttpContent to specified folder
    /// </summary>
    internal class StepContentToZipFile
        : IPipelineStep<HttpContent, FileInfo> {
        private DirectoryInfo Folder { get; }
        public StepContentToZipFile(DirectoryInfo folder) {
            Folder = folder;
        }
        public FileInfo Process(HttpContent input) {
            return new HttpContentFileStream(input, Folder).CopyToFile();
        }
    }
}
