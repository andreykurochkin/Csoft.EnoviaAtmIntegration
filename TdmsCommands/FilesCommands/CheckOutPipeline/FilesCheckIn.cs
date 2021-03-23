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
    internal abstract class FilesCheckIn {
        protected IEnumerable<TDMSObject> TdmsObjects { get; }
        protected IEnumerable<FileInfo> Files { get; }
        internal FilesCheckIn(IEnumerable<TDMSObject> tdmsObjects,
                              IEnumerable<FileInfo> files) {
            TdmsObjects = tdmsObjects;
            Files = files;
        }
        
        public IEnumerable<TDMSFile> CheckInFiles() {
            var result = new List<TDMSFile>();
            var newFiles = new List<FileInfo>(Files);
            foreach (TDMSObject tdmsObject in TdmsObjects) {
                foreach (TDMSFile tdmsFile in tdmsObject.Files) {
                    foreach (FileInfo f in Files) {
                        if (tdmsFile.FileName.Equals(f.Name)) {
                            TDMSFile checkInResult = CheckInFile(tdmsFile, f);
                            if (checkInResult != null) {
                                result.Add(checkInResult);
                                newFiles.Remove(f);
                            }
                        }
                    }
                }
                foreach (FileInfo f in newFiles) {
                    if (!tdmsObject.Files.Has(f)) {
                        var tdmsFile = tdmsObject.Files.Create("FILE_ALL");
                        TDMSFile checkInResult = CheckInFile(tdmsFile, f);
                        if (checkInResult != null) {
                            result.Add(checkInResult);
                        }
                    }
                }
            }
            return result;
        }
        internal abstract TDMSFile CheckInFile(TDMSFile tdmsFile, FileInfo file);
    }
}
