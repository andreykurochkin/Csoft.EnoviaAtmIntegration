using System;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Utilities.IO {
    /// <summary>
    /// manages creation of specific files
    /// </summary>
    public class FileFactory {
        public static void CreateFile(DirectoryInfo folder, string fileName, string content) {
            using (var file = File.CreateText($"{folder.FullName}\\{fileName}")) {
                file.WriteLine(content);
                file.Close();
            }
        }
    }
}
