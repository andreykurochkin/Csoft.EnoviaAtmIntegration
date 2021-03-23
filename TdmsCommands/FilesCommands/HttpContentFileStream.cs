using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// creates file in folder with specified name from HttpContent
    /// </summary>
    internal class HttpContentFileStream : FileStream {
        public HttpContentFileStream(HttpContent httpContent,
            DirectoryInfo folder) : base(
                new HttpContentPath(
                    new HttpContentFileName(httpContent),
                    folder
                ).ToString(),
                FileMode.OpenOrCreate
            ) {
            HttpContent = httpContent;
            Folder = folder;
        }
        private HttpContent HttpContent { get; }
        private DirectoryInfo Folder { get; }
        internal FileInfo CopyToFile() {
            using (var content = HttpContent.ReadAsStreamAsync().Result) {
                using (this) {
                    content.CopyTo(this);
                    return new FileInfo(this.Name);
                }
            }
        }
    }
}
