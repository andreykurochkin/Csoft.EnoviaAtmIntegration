using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// checks in files to Tdms objects
    /// </summary>
    internal class StepCheckInToTdmsLogged
        : IPipelineStep<IEnumerable<FileInfo>, IEnumerable<TDMSFile>> {
        public StepCheckInToTdmsLogged(IEnumerable<TDMSObject> tdmsObjects) {
            TdmsObjects = tdmsObjects;
        }
        private IEnumerable<TDMSObject> TdmsObjects { get; }
        public IEnumerable<TDMSFile> Process(IEnumerable<FileInfo> files) {
            FilesCheckIn filesCheckIn = new FilesCheckInLogged(TdmsObjects, 
                files);
            return filesCheckIn.CheckInFiles();
        }
    }
}