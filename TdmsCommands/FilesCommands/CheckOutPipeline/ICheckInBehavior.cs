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
    /// encapsulates algorithm of check-in file
    /// </summary>
    internal interface ICheckInBehavior {
        TDMSFile TdmsFile { get; }
        FileInfo FileInfo { get; }
        TDMSFile CheckIn();
    }
}
