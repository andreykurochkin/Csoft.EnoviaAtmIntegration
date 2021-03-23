using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain.Analysis {
    public class FolderFactory {
        public DateTime Cache { get ; }
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
        internal DirectoryInfo GetRootFolder() {
            return Directory
                .CreateDirectory(
                $"C:\\Users\\AP_Petrosyan_TV\\Documents\\kurochkin");
        }
    }
}
