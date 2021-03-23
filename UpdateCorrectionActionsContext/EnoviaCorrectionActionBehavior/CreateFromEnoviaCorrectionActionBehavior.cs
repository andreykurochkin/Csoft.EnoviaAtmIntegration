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
    public class CreateFromEnoviaCorrectionActionBehavior : IUpdateCorrectionActionsBehavior
    {
        private IUpdateCorrectionActionsBehavior behavior;

        public CreateFromEnoviaCorrectionActionBehavior(UpdateContext client, ICa enoviaCorrectionAction)
        {
            behavior = new CreateFromEcaItemsBehavior(client, new List<ICa>() { enoviaCorrectionAction });
        }

        public void ProcessItems()
        {
            behavior.ProcessItems();
        }
    }

}
