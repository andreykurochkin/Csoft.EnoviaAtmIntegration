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

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class PutSentToTdmsRequestFactoryCleanOutDate : IPutHttpRequestMessageFactory {
        private string Id { get; }
        private IPutHttpRequestMessageFactory Origin { get; }
        public AuthenticationHeaderValue CreateAuthenticationHeaderValue() {
            throw new NotImplementedException();
        }
        public StringContent CreateStringContent() {
            throw new NotImplementedException();
        }
        public Uri CreateUri() {
            throw new NotImplementedException();
        }
    }

}