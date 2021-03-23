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
    public class Ars : IEnumerable<Ar> {
        public Ars(TarFactories factories) {
            factories.ToList().ForEach(f => Items.Add(new Ar(f).Configure()));
        }
        public List<Ar> Items { get; } = new();
        public IEnumerator<Ar> GetEnumerator() {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return Items.GetEnumerator();
        }
    }
}