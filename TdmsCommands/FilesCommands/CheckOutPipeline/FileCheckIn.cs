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
    /// checks in file to tdmsfile
    /// </summary>
    internal class FileCheckIn : ICheckInBehavior {
        public FileCheckIn(TDMSFile tdmsFile, FileInfo fileInfo) {
            TdmsFile = tdmsFile;
            FileInfo = fileInfo;
        }
        public TDMSFile TdmsFile { get; }
        public FileInfo FileInfo { get; }
        public TDMSFile CheckIn() {
            TdmsFile.CheckIn(FileInfo.FullName);
            return TdmsFile;
        }
    }
    internal class FileCheckInDirect : ICheckInBehavior {
        public FileCheckInDirect(TDMSFile tdmsFile, FileInfo fileInfo) {
            TdmsFile = tdmsFile;
            FileInfo = fileInfo;
        }
        public TDMSFile TdmsFile { get; }
        public FileInfo FileInfo { get; }
        public TDMSFile CheckIn() {
            TdmsFile.CheckInDirect(FileInfo.FullName);
            return TdmsFile;
        }
    }
}
