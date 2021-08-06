using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class AdditionalFilter : IEnumerable<Ar> {
        private List<Ar> Items { get; } = new();
        public AdditionalFilter(IEnumerable<Ar> ars) {
            ars.Where(a =>!string.IsNullOrEmpty(a.NppUnit))
                .Where(a =>!string.IsNullOrEmpty(a.SetCode))
                .Where(a =>!string.IsNullOrEmpty(a.SetName))
                .ToList().ForEach(a => Items.Add(a));
        }
        public IEnumerator<Ar> GetEnumerator() {
            return Items.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return Items.GetEnumerator();
        }
    }
}