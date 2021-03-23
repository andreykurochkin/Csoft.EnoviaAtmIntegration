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
    public class CreateNewItemsFromRootFileBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext client;

        public CreateNewItemsFromRootFileBehavior(UpdateContext client)
        {
            this.client = client;
        }
        /// <summary>
        /// Creates EnoviaCorrectionActions from txt file of root object
        /// </summary>
        public void ProcessItems()
        {
            var strategy = new CreateFromEcaItemsBehavior(client, Utility.GetObjects(client.TdmsContext.CaRoot));
            strategy.ProcessItems();
        }
    }

}
