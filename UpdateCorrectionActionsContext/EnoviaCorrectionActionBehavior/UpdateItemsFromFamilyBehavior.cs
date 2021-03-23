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
    public class UpdateItemsFromFamilyBehavior : IUpdateCorrectionActionsBehavior
    {
        private UpdateContext client;

        public UpdateItemsFromFamilyBehavior(UpdateContext client)
        {
            this.client = client;
        }

        public void ProcessItems()
        {
            var oldItems = Utility.GetObjects(client.TdmsContext.CaRoot);
            var newItems = GetNewCorrectionActions();
            var family = new EnoviaCorrectionActionsFamily(oldItems, newItems);

            var modifiedItemsFamily = new ModifiedEnoviaCorrectionActions(family);
            var strategy = new CreateFromEcaItemsBehavior(client, modifiedItemsFamily.Items);
            strategy.ProcessItems();
        }

        private IEnumerable<ICa> GetNewCorrectionActions()
        {
            if (Environment.MachineName.Equals("KUROCHKIN-NB"))
            {
                return Utility.GetObjects(@"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\content\results-Strings\EnoviaCorrectionActions\11-09-2020-19-42-18.txt");
            }
            return Utility.GetObjects();
        }
    }

}
