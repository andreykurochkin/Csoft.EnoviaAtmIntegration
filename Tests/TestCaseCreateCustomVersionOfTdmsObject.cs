using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{

    /// <summary>
    /// Creates version of TdmsObject
    /// </summary>
    class TestCaseCreateCustomVersionOfTdmsObject : TestCaseBase
    {
        public TestCaseCreateCustomVersionOfTdmsObject(TDMSApplication application) : base(application) { }

        public override void Execute()
        {
            CreateVersion();
        }

        internal void CreateVersion()
        {
            var tdmsClient = new TdmsContext(application);
            tdmsClient.CaRoot.Objects.ForEach(o => CreateVersion(o));
        }

        internal void CreateVersion(TDMSObject tdmsObject)
        {
            CreateVersion(tdmsObject.GUID);
        }
        internal void CreateVersion(string guid)
        {
            var tdmsObject = application.GetObjectByGUID(guid);
            var versions = tdmsObject.Versions;
            var versionName = versions.Count + 1;
            var versionDescription = $"export @: {DateTime.Now.ToString()}";
            versions.Create(versionName, versionDescription);
        }
    }
}
