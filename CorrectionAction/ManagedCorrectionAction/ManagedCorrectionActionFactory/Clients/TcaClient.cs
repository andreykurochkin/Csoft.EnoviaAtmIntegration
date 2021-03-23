using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Security.Cryptography.X509Certificates;
using Csoft.EnoviaAtmIntegration.Domain;
namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Incapsulates data to create tdmsObjects
    /// </summary>
    public class TcaClient : ICaClient {
        private NppMaps nppMaps;
        private ICaClient mcaClient;
        public TcaClient(ICaClient mcaClient) : this(mcaClient, new NppMaps()) { }
        public TcaClient(ICaClient mcaClient, NppMaps nppMaps) {
            this.mcaClient = mcaClient;
            this.nppMaps = nppMaps;
        }
        public IEnumerable<ICa> CreateItems() {
            return mcaClient
                .CreateItems()
                .Select(
                    mCa => new Ca(new TcaFactory(mCa)).Configure()
                );
        }
    }
}
