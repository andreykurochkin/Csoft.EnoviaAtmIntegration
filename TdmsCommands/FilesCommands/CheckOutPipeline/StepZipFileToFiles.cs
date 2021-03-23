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
    /// unzips zip file to layout folder
    /// </summary>
    internal class StepZipFileToFiles
        : IPipelineStep<FileInfo, IEnumerable<FileInfo>> {
        private DirectoryInfo Folder { get; }
        public StepZipFileToFiles(DirectoryInfo folder) {
            Folder = folder;
        }
        public IEnumerable<FileInfo> Process(FileInfo input) {
            var layoutFolder = Folder.CreateSubdirectory(
                Path.GetFileNameWithoutExtension(input.FullName)
            );
            ZipFile.ExtractToDirectory(input.FullName, layoutFolder.FullName);
            return layoutFolder.GetFiles();
        }
    }
}
