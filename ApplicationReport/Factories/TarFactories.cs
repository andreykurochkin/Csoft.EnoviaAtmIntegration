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
    public class TarFactories : IEnumerable<TarFactory> {
        private List<TarFactory> Factories { get; } = new();
        public TarFactories(IEnumerable<TDMSTableAttributeRow> rows) {
            rows.ToList().ForEach(r =>
            Factories.Add(new TarFactory(r)));
        }
        public IEnumerator<TarFactory> GetEnumerator() {
            return Factories.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return Factories.GetEnumerator();
        }
    }
}