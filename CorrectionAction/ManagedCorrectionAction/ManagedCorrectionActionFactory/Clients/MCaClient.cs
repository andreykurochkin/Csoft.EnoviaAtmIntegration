using Csoft.EnoviaAtmIntegration.Domain;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain {
    public class McaClient : ICaClient {
        private IEnumerable<ICa> correctionActions = new List<ICa>();
        public McaClient(IEnumerable<ICa> correctionActions) {
            this.correctionActions = correctionActions;
        }
        public IEnumerable<ICa> CreateItems() {
            return correctionActions
                .SelectMany(eca => new SystemsRelationships(eca))
                .Select(
                    sr => new Ca(new McaFactory(sr.Eca, sr)).Configure()
                );
        }
    }
}
