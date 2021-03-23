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
    public class EnoviaPutHttpClientLogged : EnoviaPutHttpClient {
        private ILogger Log { get; }
        private EnoviaPutHttpClient Origin { get; }
        public EnoviaPutHttpClientLogged(EnoviaPutHttpClient origin, ILogger log) {
            Origin = origin;
            Log = log;
        }
        public override Task<HttpResponseMessage> PutAsync(
            IPutHttpRequestMessageFactory factory) {
            var task = Origin.PutAsync(factory);
            Log.Debug("--------------------------------------");
            Log.Debug("tdms->enovia pdSentToTdms date update");
            Log.Debug($"uri: " +
                $"{factory.CreateUri()}");
            Log.Debug($"IsSuccessStatusCode: " +
                $"{task.Result.IsSuccessStatusCode}");
            Log.Debug($"StatusCode: " +
                $"{task.Result.StatusCode}");
            Log.Debug("--------------------------------------");
            return task;
        }
    }

}