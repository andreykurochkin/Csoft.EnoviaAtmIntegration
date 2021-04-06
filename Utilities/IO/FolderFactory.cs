using System;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Utilities.IO {
    public class FolderFactory {
        private DateTime Cache { get ; }
        public FolderFactory(DateTime cache) {
            this.Cache = cache;
        }
        private string GetDateTimeName() {
            return new DashedFormat(
                new RussianDateTimeFormat(Cache)
            ).Format();
        }
        internal DirectoryInfo GetLayoutFolder() {
            var root = GetRootFolder();
            return root.CreateSubdirectory(GetDateTimeName());
        }
        // todo move to some other class
        internal DirectoryInfo GetRootFolder() {
            return Directory
                .CreateDirectory(
                $"C:\\Users\\AP_Petrosyan_TV\\Documents\\kurochkin");
        }
    }
}
