using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// projects each attribute of object into an inner List<TDMSAttribute>
    /// </summary>
    public class Attributes : IEnumerable<TDMSAttribute> {
        private List<TDMSAttribute> list = new List<TDMSAttribute>();
        public Attributes(TDMSObjects objs, string name) {
            Objs = objs;
            Name = name;
            foreach (var obj in Objs) {
                var attrs = obj.Attributes;
                if (attrs.Has(Name))
                    list.Add(attrs[Name]);
            }
        }
        private TDMSObjects Objs { get; }
        private string Name { get; }
        public IEnumerator<TDMSAttribute> GetEnumerator() {
            return list.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return list.GetEnumerator();
        }
    }
}
