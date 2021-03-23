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
    public class ArRequests : IEnumerable<IArPostRequest>
    {
        private List<IArPostRequest> arRequests= 
            new List<IArPostRequest>();

        public ArRequests(IEnumerable<Ar> ars)
        {
            ars.ToList().ForEach(ar =>
            arRequests.Add(new ArRequest(ar)));
        }

        public IEnumerator<IArPostRequest> GetEnumerator()
        {
            return arRequests.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return arRequests.GetEnumerator();
        }

        public void PostAsync()
        {
            arRequests.ForEach(r => r.PostAsync());
        }
    }
}