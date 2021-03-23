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
    /// Creates new TdmsObjects from Tdms Correction Actions with specific export date
    /// </summary>
    public class CreateFromTcaItemsWithExportDateBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext client;
        private IEnumerable<ICa> correctionActions;
        private DateTime exportDateTime;

        public CreateFromTcaItemsWithExportDateBehavior(UpdateContext client, IEnumerable<ICa> tdmsCorrectionActions, DateTime exportDateTime)
        {
            this.client = client;
            this.correctionActions = tdmsCorrectionActions;
            this.exportDateTime= exportDateTime;
        }

        public void ProcessItems()
        {
            this.correctionActions.ToList().ForEach(tdmsCorrectionAction =>
            {
                var newTdmsObject = this.client.TdmsContext.CreateCaTdmsObject();
                this.client.TdmsContext.InitializeCaFields(newTdmsObject, tdmsCorrectionAction,exportDateTime);
            });
        }
    }
}
