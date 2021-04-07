using System;
using System.IO;
using Csoft.EnoviaAtmIntegration.Utilities;

namespace Csoft.EnoviaAtmIntegration.Utilities.IO {
    /// <summary>
    /// manages creation of specific folders
    /// </summary>
    public class FolderFactory {
        private DateTime DateTime { get ; }
        private Lazy<IFormattable> DashedFormat { get; }
        private string Path { get; }
        public FolderFactory(DateTime dateTime, string path) {
            DateTime = dateTime;
            Path = path;
            DashedFormat = new(
                new DashedFormat(
                    new RussianDateTimeFormat(
                        DateTime
                    )
                )
            );
        }
        internal DirectoryInfo GetLayoutFolder() {
            return GetRootFolder().CreateSubdirectory(DashedFormat.Value.Format());
        }
        internal DirectoryInfo GetRootFolder() {
            return Directory.CreateDirectory(Path);
        }
    }
}
