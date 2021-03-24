using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// Creates new TdmsObjects from Enovia Correction Actions
    /// </summary>
    public class CreateFromEcaItemsBehavior : IUpdateCorrectionActionsBehavior {
        private UpdateContext UpdateContext { get; }
        private IEnumerable<ICa> Tcas { get => tcas.Value; }
        private Lazy<IEnumerable<ICa>> tcas;
        public CreateFromEcaItemsBehavior(UpdateContext client, IEnumerable<ICa> correctionActions) {
            UpdateContext = client;
            tcas = new Lazy<IEnumerable<ICa>>(() => {
                var ICaClient = new KudanTcaClient(
                    new TcaClient(
                        new McaClient(correctionActions)
                    )
                );
                return ICaClient.CreateItems();
            });
        }
        public void ProcessItems() {
            new CreateFromTcaItemsBehavior(UpdateContext, Tcas).ProcessItems();
        }
    }
}
