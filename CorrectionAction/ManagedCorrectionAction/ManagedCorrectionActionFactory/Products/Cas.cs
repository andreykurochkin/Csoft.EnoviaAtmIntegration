using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public abstract class Cas : IEnumerable<ICa> {
        protected List<ICa> list = new();
        public IEnumerator<ICa> GetEnumerator() => list.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => list.GetEnumerator();
        protected IEnumerable<ICa> CreateICas(string json) {
            var objs = JsonConvert.DeserializeObject<List<Ca>>(json);
            return objs;
        }
    }
}