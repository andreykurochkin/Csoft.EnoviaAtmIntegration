using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Csoft.EnoviaAtmIntegration.Domain.Analysis;
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

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// configures put request to erase Enovia attribute pdSentToTdms 
    /// </summary>
    public class CleanOutDatePutSentToTdmsRequestFactory : IPutHttpRequestMessageFactory {
        public CleanOutDatePutSentToTdmsRequestFactory(IPutHttpRequestMessageFactory origin) {
            Origin = origin;
        }
        private IPutHttpRequestMessageFactory Origin { get; }
        public AuthenticationHeaderValue CreateAuthenticationHeaderValue() {
            return Origin.CreateAuthenticationHeaderValue();
        }
        public StringContent CreateStringContent() {
            var json = "{\"pdSentToTDMS\":" + "\"" + "\'\'" + "\"" + "}";
            return new StringContent(json, Encoding.UTF8, "application/json"); ;
        }
        public Uri CreateUri() {
            return Origin.CreateUri();
        }
    }

}