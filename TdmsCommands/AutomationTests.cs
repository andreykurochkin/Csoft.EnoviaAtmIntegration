using Newtonsoft.Json;
using Newtonsoft.Json.Schema;
using Csoft.EnoviaAtmIntegration.Domain.Tests;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;
using Tdms.Tasks;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    [TdmsApi("AutomationTests")]
    public class AutomationTests
    {
        private readonly TDMSApplication app;
        private List<ITdmsTest> tests = new List<ITdmsTest>();
        public AutomationTests(TDMSApplication application)
        {
            this.app = application;
        }
        public void Execute()
        {
            new Services.UpdateService(app).Execute(new System.Threading.CancellationToken());
        }
    }
}
