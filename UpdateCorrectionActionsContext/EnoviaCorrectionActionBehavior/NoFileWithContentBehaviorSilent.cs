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
    public class NoFileWithContentBehaviorSilent : IUpdateCorrectionActionsBehavior
    {
        private readonly IUpdateCorrectionActionsBehavior strategy;
        //private UpdateContext client;

        public NoFileWithContentBehaviorSilent(UpdateContext client)
        {
            this.strategy = new NoFileWithContentBehavior(client);
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
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }

}
