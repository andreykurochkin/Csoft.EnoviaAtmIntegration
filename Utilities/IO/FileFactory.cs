using System;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Utilities.IO {
    /// <summary>
    /// creates new file and writes out string to it
    /// </summary>
    public class FileFactory {
        public static void CreateFile(DirectoryInfo folder, string fileName, string content) {
            using var file = File.CreateText($"{folder.FullName}\\{fileName}"); 
            file.WriteLine(content);
            file.Close();
        }
    }
}
