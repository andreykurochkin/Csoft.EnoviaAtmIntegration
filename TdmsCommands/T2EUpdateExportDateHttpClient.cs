using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Encapsulates authorization to Enovia
    /// </summary>
    public class T2EUpdateExportDateHttpClient : HttpClient
    {
        public T2EUpdateExportDateHttpClient()
        {
            this.DefaultRequestHeaders.Authorization =
                new EnoviaBasicAuthenticationHeaderValue();
        }
    }
}