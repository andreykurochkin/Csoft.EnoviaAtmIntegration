using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tdms.Api;

namespace Csoft.EnoviaAtmIntegration.Domain.Tests
{
    /// <summary>
    /// Updates export date in Enovia
    /// </summary>
    class TestCaseUpdateExportDate : ITdmsTest
    {
        private TDMSApplication application;

        public TestCaseUpdateExportDate(TDMSApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            new T2EUpdateExportDate(application).Execute();
        }
    }

    /// <summary>
    /// Updates export date in Enovia
    /// </summary>
    class TestCaseUpdateExportDateMock : ITdmsTest
    {
        private TDMSApplication application;

        public TestCaseUpdateExportDateMock(TDMSApplication application)
        {
            this.application = application;
        }

        public void Execute()
        {
            T2EUpdateExportDateMock.Execute();
        }
    }
}