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
    public class CreateNewItemsFromEnoviaBehavior : IUpdateCorrectionActionsBehavior
    {
        protected UpdateContext client;
        public CreateNewItemsFromEnoviaBehavior(UpdateContext client)
        {
            this.client = client;
        }
        public void ProcessItems()
        {
            var strategy = new CreateFromEcaItemsBehavior(client, GetEnoviaCorrectionActions());
            strategy.ProcessItems();
        }
        protected virtual IEnumerable<ICa> GetEnoviaCorrectionActions()
        {
            return Utility.GetObjects();
        }
    }

}
