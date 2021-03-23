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
    /// logs check in process
    /// </summary>
    internal class FilesCheckInLogged : FilesCheckIn {
        internal FilesCheckInLogged(IEnumerable<TDMSObject> tdmsObjects,
                                    IEnumerable<FileInfo> files)
            : base(tdmsObjects, files) {
        }
        internal override TDMSFile CheckInFile(TDMSFile tdmsFile,
                                               FileInfo file) {
            return
                new FileCheckInSafe(
                    new FileCheckInLogged(
                        //new FileCheckIn(tdmsFile, file)
                        new FileCheckInDirect(tdmsFile, file)
                    )
                ).CheckIn();
        }
    }
}
