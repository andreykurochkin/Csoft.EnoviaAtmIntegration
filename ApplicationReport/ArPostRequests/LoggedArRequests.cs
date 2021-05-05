using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Tdms;
using Tdms.Log;
using System.Collections;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// decorates ArRequests with forecast and report logs
    /// </summary>
    public class LoggedArRequests : IEnumerable<IArPostRequest> {
        private List<IArPostRequest> Requests { get; } = new();
        public IEnumerable<IArPostRequest> Origin { get; }
        public LoggedArRequests(IEnumerable<IArPostRequest> origin) {
            Origin = origin;
            Origin.ToList().ForEach(r => Requests.Add(new LoggedArRequest(r)));
        }
        public IEnumerator<IArPostRequest> GetEnumerator() {
            return Origin.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return Origin.GetEnumerator();
        }
        public void PostAsync() {
            var log = LogManager.GetLogger($"{typeof(LoggedArRequest)}");
            log.Debug("forecast");
            log.Debug($"expected application reports: {Requests.Count}");
            Requests.ForEach(r => r.PostAsync());
            log.Debug("report");
            var goodRequests = Requests.Where(r => r.TaskResponse.Result.IsSuccessStatusCode);
            log.Debug($"created application reports: {goodRequests.Count()}");
        }
    }
}