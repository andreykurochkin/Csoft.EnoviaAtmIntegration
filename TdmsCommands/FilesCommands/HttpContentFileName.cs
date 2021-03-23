using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// retrieves fileName from HttpContent
    /// </summary>
    public class HttpContentFileName {
        HttpContent HttpContent { get; }
        public HttpContentFileName(HttpContent httpContent) {
            HttpContent = httpContent;
        }
        public override string ToString() {
            return HttpContent.Headers.ContentDisposition.FileName
                .Replace("\"", "");
        }
    }
}
