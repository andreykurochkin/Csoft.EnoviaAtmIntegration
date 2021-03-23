using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{

    class TestCaseCreateWithExportDate : ITdmsTest
    {
        private TDMSApplication application;

        public TestCaseCreateWithExportDate(TDMSApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            new TestCaseDeleteObjectsFromContent(application).Execute();
            IEnumerable<ICa> ecaItems = Utility.GetObjects(@"c:\Users\kurochkin.andrei\Documents\02-work\01-Projects\01-web-service\content\results-Strings\EnoviaCorrectionActions\10-09-2020-9-30-46.txt");
            new CreateFromEcaItemsWithExportDateBehavior(new UpdateContext(application), ecaItems, new DateTime(2020, 9, 10)).ProcessItems();
        }
    }
}