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
    /// checks in file to tdmsfile with log
    /// </summary>
    internal class FileCheckInLogged : ICheckInBehavior {
        public FileCheckInLogged(ICheckInBehavior origin) {
            Origin = origin;
            Log = LogManager.GetLogger($"{nameof(FileCheckInLogged)}");
        }
        public TDMSFile TdmsFile => Origin.TdmsFile;
        public FileInfo FileInfo => Origin.FileInfo;
        ICheckInBehavior Origin { get; }
        ILogger Log { get; }
        public TDMSFile CheckIn() {
            try {
                Log.Debug("successfully file check in to tdms file");
                return Origin.CheckIn();
            }
            catch (Exception) {
                Log.Debug("error on file check in to tdms file");
                Log.Debug($"tdmsobject: {Origin.TdmsFile.Owner.GUID}");
                Log.Debug($"tdmsfile: {Origin.TdmsFile.Handle}");
                Log.Debug($"path: {Origin.FileInfo.FullName}");
                throw;
            };
        }
    }
}
