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
    /// safe invocation
    /// </summary>
    internal class FileCheckInSafe : ICheckInBehavior {
        public FileCheckInSafe(ICheckInBehavior origin) {
            Origin = origin;
        }

        public TDMSFile TdmsFile => Origin.TdmsFile;

        public FileInfo FileInfo => Origin.FileInfo;

        private ICheckInBehavior Origin { get; }
        public TDMSFile CheckIn() {
            try {
                return Origin.CheckIn();
            }
            catch (Exception) {
                return null;
            }
        }
    }
}
