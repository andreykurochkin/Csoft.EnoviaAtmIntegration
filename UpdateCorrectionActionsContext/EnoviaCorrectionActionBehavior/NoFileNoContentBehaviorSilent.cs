using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    public class NoFileNoContentBehaviorSilent : IUpdateCorrectionActionsBehavior
    {
        private readonly IUpdateCorrectionActionsBehavior strategy;
        //private UpdateContext client;

        public NoFileNoContentBehaviorSilent(UpdateContext client)
        {
            this.strategy = new CreateNewItemsFromEnoviaBehavior(client);
        }
        public void ProcessItems()
        {
            try
            {
                strategy.ProcessItems();
            }
            catch (Exception ex)
            {
                // todo log exception
                Debug.WriteLine(ex.Message);
            }
        }
    }

}
