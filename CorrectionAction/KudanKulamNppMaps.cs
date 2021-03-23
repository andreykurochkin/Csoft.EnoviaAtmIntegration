using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// retrieves KudanKulamNppMap items
    /// </summary>
    public class KudanKulamNppMaps : IEnumerable<NppMap> {
        private List<NppMap> List { get; } = new List<NppMap>();
        private readonly string Pattern = "АЭС Куданкулам";
        public KudanKulamNppMaps() {
            var query = new NppMaps().Where(nppMap => nppMap.Name.Equals(Pattern));
            List.AddRange(query);
        }
        public IEnumerator<NppMap> GetEnumerator() {
            return List.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return List.GetEnumerator();
        }
    }
}
