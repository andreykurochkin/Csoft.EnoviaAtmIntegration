using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// retrieves file path from folder and HttpContent
    /// </summary>
    public class HttpContentPath {
        private HttpContentFileName origin;
        private DirectoryInfo directory;
        public HttpContentPath(HttpContentFileName origin,
            DirectoryInfo directory) {
            this.origin = origin;
            this.directory = directory;
        }
        public override string ToString() {
            return Path.Combine($"{directory.FullName}\\" +
                $"{origin.ToString()}");
        }
    }
}
