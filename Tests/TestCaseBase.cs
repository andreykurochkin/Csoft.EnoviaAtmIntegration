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
    public abstract class TestCaseBase : ITdmsTest
    {
        protected readonly TDMSApplication application;

        public TestCaseBase(TDMSApplication application)
        {
            this.application = application;
        }

        public abstract void Execute();
    }
}
