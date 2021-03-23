using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Tdms.Log;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// puts data to Enovia
    /// </summary>
    public class EnoviaPutHttpClient : HttpClient {
        public virtual Task<HttpResponseMessage> PutAsync(IPutHttpRequestMessageFactory factory) {
            DefaultRequestHeaders.Authorization = factory.CreateAuthenticationHeaderValue();
            return PutAsync(factory.CreateUri(), factory.CreateStringContent());
        }
    }

}