using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// leaves items with KudanKulam
    /// </summary>
    public class KudanKulamTcaClient : ICaClient {
        private ICaClient Origin { get; }
        private Lazy<IEnumerable<string>> kudanKulamGuids;
        private IEnumerable<string> KudanKulamGuids { get => kudanKulamGuids.Value; }
        public KudanKulamTcaClient(ICaClient origin) {
            Origin = origin;
            kudanKulamGuids = new Lazy<IEnumerable<string>>(() =>
                new KudanKulamNppMaps().Select(nppMap => nppMap.Guid)
            );
        }
        public IEnumerable<ICa> CreateItems() {
            var tcas = Origin.CreateItems();
            var query = tcas.Where(tca =>
                tca.Npps.ToList().Intersect(KudanKulamGuids).Any()
            );
            return query.ToList();
        }
    }
}
