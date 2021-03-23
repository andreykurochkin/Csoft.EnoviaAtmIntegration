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
    /// creates new tdmsobjects from tdms correction actions
    /// </summary>
    public class CreateFromTcaItemsBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext client;
        private IEnumerable<ICa> correctionActions;

        public CreateFromTcaItemsBehavior(UpdateContext client, IEnumerable<ICa> tdmsCorrectionActions)
        {
            this.client = client;
            this.correctionActions = tdmsCorrectionActions;
        }

        public void ProcessItems()
        {
            this.correctionActions.ToList().ForEach(tdmscorrectionaction =>
             {
                 var newtdmsobject = this.client.TdmsContext.CreateCaTdmsObject();
                 this.client.TdmsContext.InitializeCaFields(newtdmsobject, tdmscorrectionaction);
             });
        }
    }
}
