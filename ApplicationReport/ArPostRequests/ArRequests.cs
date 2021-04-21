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
    public class ArRequests : IEnumerable<IArPostRequest> {
        private List<IArPostRequest> Requests {
            get {
                return requests.Value;
            }
        }
        private Lazy<List<IArPostRequest>> requests;
        public ArRequests(IEnumerable<Ar> ars) {
            requests = new(() => 
            {
                List<IArPostRequest> result = new();
                using var client = new HttpClient();
                ars.ToList().ForEach(ar => result.Add(new ArRequest(ar, client)));
                return result;
            });
        }
        public IEnumerator<IArPostRequest> GetEnumerator() {
            return Requests.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return Requests.GetEnumerator();
        }
        public void PostAsync() => Requests.ForEach(r => r.PostAsync());
    }
}
