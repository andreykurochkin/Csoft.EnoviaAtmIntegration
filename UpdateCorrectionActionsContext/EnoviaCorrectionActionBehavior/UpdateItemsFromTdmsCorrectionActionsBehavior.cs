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
    /// Updates TdmsObjects from Tdms Correction Actions
    /// </summary>
    public class UpdateItemsFromTdmsCorrectionActionsBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext client;
        private IEnumerable<ICa> correctionActions;
        private TDMSObject tdmsObject;
        private int versionName;

        public UpdateItemsFromTdmsCorrectionActionsBehavior(UpdateContext client, IEnumerable<ICa> correctionActions, TDMSObject tdmsObject, int versionName)
        {
            this.client = client;
            this.correctionActions = correctionActions;
            this.tdmsObject = tdmsObject;
            this.versionName = versionName;
        }

        public void ProcessItems()
        {
            this.correctionActions.ToList().ForEach(restoredTdmsCorrectionAction =>
            {
                var version = this.client.TdmsContext.CreateCaVersion(tdmsObject, versionName);
                this.client.TdmsContext.InitializeCaFields(version, versionName, restoredTdmsCorrectionAction);
            });
        }
    }
}
