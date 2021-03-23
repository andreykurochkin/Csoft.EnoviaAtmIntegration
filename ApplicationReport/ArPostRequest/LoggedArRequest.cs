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
    public class LoggedArRequest : IArPostRequest
    {
        private IArPostRequest origin;

        public LoggedArRequest(IArPostRequest request)
        {
            this.origin = request;
        }

        public Ar Ar => origin.Ar;

        public HttpResponseMessage Response => 
            origin.Response;

        public HttpResponseMessage PostAsync()
        {
            var log = LogManager.GetLogger($"{typeof(LoggedArRequest)}");

            log.Debug("forecast: new application report");
            log.Debug($"{origin.Ar.ToString()}");
            
            var answer = origin.PostAsync();
            
            log.Debug($"report");
            log.Debug($"status code: {answer.StatusCode}");
            return answer;
        }
    }
}