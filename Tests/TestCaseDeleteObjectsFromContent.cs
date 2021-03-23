using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    /// <summary>
    /// Deletes tdmsObjects
    /// </summary>
    class TestCaseDeleteObjectsFromContent : TestCaseBase
    {
        private string rootGuid;

        public TestCaseDeleteObjectsFromContent(TDMSApplication application) : base(application)
        {
            rootGuid = new TdmsContext(application).CaRoot.GUID;
        }

        TDMSObject Root => application.GetObjectByGUID(rootGuid);

        public override void Execute()
        {
            Root.Objects.ForEach(o => o.Erase());
        }
    }
}
