using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public abstract class CsoftHttpClient
    {
        HttpRequestMessage httpRequestMessage;

        public string GetResponse(string format)
        {
            httpRequestMessage = CreateHttpRequestMessage(format);
            
            Task<HttpResponseMessage> httpResponse = 
                (new HttpClient()).SendAsync(httpRequestMessage);
            HttpResponseMessage httpResponseMessage = 
                httpResponse.Result;

            HttpContent responseContent = 
                httpResponseMessage.Content;
            Task<string> responseData = 
                responseContent.ReadAsStringAsync();
            string result = responseData.Result;
            return result;
        }
        internal abstract HttpRequestMessage CreateHttpRequestMessage(string format);
    }
}