using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    class TestCaseExportDate : TestCaseBase
    {
        public TestCaseExportDate(TDMSApplication application) : base(application) { }

        public override void Execute()
        {
            var tdmsContext = new UpdateContext(application).TdmsContext;
            var date = new LastExportDate(tdmsContext.CaRoot.Objects, TdmsContext.CaAttrExportName).DateTime;
        }
    }
}
