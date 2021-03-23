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
    /// decorates ArRequests with forecast and report logs
    /// </summary>
    public class LoggedArRequests 
        : IEnumerable<IArPostRequest>
    {
        private IEnumerable<IArPostRequest> origin;
        private List<IArPostRequest> requests =
            new List<IArPostRequest>();

        public LoggedArRequests(
            IEnumerable<IArPostRequest> requests)
        {
            this.origin = requests;
            origin.ToList().ForEach(r => 
            this.requests.Add(new LoggedArRequest(r)));
        }

        public IEnumerator<IArPostRequest> GetEnumerator()
        {
            return origin.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return origin.GetEnumerator();
        }

        public void PostAsync()
        {
            var log = LogManager.GetLogger(
                $"{typeof(LoggedArRequest)}");

            log.Debug("forecast");
            log.Debug($"expected application reports: " +
                $"{requests.Count()}");
            
            requests.ForEach(r => r.PostAsync());
            var goodRequests = requests
                .Where(r => r.Response.IsSuccessStatusCode);

            log.Debug("report");
            log.Debug($"created application reports: " +
                $"{goodRequests.Count()}");
        }
    }
}