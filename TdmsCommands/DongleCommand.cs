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
    [TdmsApi("DongleCommand")]
    class DongleCommand
    {
        private readonly TDMSApplication application;

        public DongleCommand(TDMSApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            var client = new UpdateContext(application);
            client.CreateOrUpdateCorrectionActions();
            client.TdmsContext.UploadFileFromEnovia();
        }
    }
}
