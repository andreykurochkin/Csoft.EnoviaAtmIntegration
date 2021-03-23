using System.Collections.Generic;
using System.Linq;
namespace Csoft.EnoviaAtmIntegration.Domain {
    public class ListContentEqualityComparer : IEqualityComparer<List<string>> {
        public bool Equals(List<string> x, List<string> y) {
            return x.IsContentEqual(y);
        }
        public int GetHashCode(List<string> obj) {
            return obj.Aggregate(0, (result, next) => result ^= next.GetHashCode());
        }
    }
}
