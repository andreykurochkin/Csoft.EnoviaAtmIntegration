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
using Tdms;
using Tdms.Api;
using Tdms.Tasks;
using System.Net.Http.Headers;
using Tdms.Log;
using System.Collections;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// decorates ArRequest with log on PostAsync call
    /// </summary>
    public class LoggedArRequest : IArPostRequest {
        private IArPostRequest Origin { get; }
        private ILogger Log { get; } = LogManager.GetLogger($"{typeof(LoggedArRequest)}");
        public LoggedArRequest(IArPostRequest request) {
            Origin = request;
        }
        public Ar Ar { get => Origin.Ar; }
        public HttpResponseMessage Response { get => Origin.TaskResponse.Result; }
        public HttpResponseMessage PostAsync() {
            Log.Debug("forecast: new application report");
            Log.Debug($"{Origin.Ar.ToString()}");
            var responseMessage = Origin.PostAsync().Result;
            Log.Debug($"report");
            Log.Debug($"status code: {responseMessage.StatusCode}");
            return responseMessage;
        }
    }
}