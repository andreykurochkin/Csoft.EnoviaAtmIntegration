using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public abstract class Cas : IEnumerable<ICa>
    {
        protected List<ICa> list = new List<ICa>();

        public IEnumerator<ICa> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }

        protected IEnumerable<ICa> CreateICas(string json)
        {
            var objs = JsonConvert.DeserializeObject<List<Ca>>(json);
            return objs;
        }
    }
}