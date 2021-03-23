using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// Creates new TdmsObjects from Enovia Correction Actions
    /// </summary>
    public class CreateFromEcaItemsWithExportDateBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext UpdateContext { get; }
        private IEnumerable<ICa> Tcas { get => tcas.Value; }
        private Lazy<IEnumerable<ICa>> tcas;
        private DateTime exportDateTime;
        public CreateFromEcaItemsWithExportDateBehavior(UpdateContext client,
                                                        IEnumerable<ICa> correctionActions,
                                                        DateTime exportDateTime)
        {
            UpdateContext = client;
            this.exportDateTime = exportDateTime;
            tcas = new Lazy<IEnumerable<ICa>>(() => {
                var ICaClient = new KudanKulamTcaClient(
                    new TcaClient(
                        new McaClient(correctionActions)
                    )
                );
                return ICaClient.CreateItems();
            });
        }

        public void ProcessItems()
        {
            new CreateFromTcaItemsWithExportDateBehavior(
                UpdateContext, 
                Tcas, 
                exportDateTime)
            .ProcessItems();
        }
    }

}
