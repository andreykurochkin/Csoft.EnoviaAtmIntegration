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
using System.Collections;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class MainFilter : IEnumerable<Ar>
    {
        private List<Ar> items = new List<Ar>();

        public MainFilter(IEnumerable<Ar> ars)
        {
            ars
                .Where(a => 
                !string.IsNullOrEmpty(a.SystemName))
                .Where(a => 
                !string.IsNullOrEmpty(a.ApplicantName))
                .Where(a => 
                !string.IsNullOrEmpty(a.EcaId))
                .ToList().ForEach(a=>items.Add(a));
        }

        public IEnumerator<Ar> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}