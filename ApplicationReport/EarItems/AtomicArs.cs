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
    public class AtomicArs : IEnumerable<Ar>
    {
        private List<Ar> items = new List<Ar>();

        public AtomicArs(IEnumerable<Ar> ars)
        {
            ars
                .SelectMany(e => e.SystemName.ToListOrDash(),
                (e, s) => new { e, s })
                .SelectMany(es => es.e.BuildingName.ToList(),
                (es, b) => new { es, b })
                .SelectMany(esb => esb.es.e.NppUnit.ToList(),
                (esb, n) => new { esb, n })
                .Select(esbn => 
                new Ar(esbn.esb.es.e)
                {
                    NppUnit = esbn.n,
                    BuildingName = esbn.esb.b,
                    SystemName = esbn.esb.es.s
                }).ToList().ForEach(a=>items.Add(a));
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