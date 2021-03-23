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
    internal class TwoEcaItemsExport
    {
        protected TDMSApplication application;
        protected IEnumerable<ICa> enoviaCorrectionActions;

        internal TwoEcaItemsExport(TDMSApplication application)
        {
            this.application = application;
            enoviaCorrectionActions = CreateEnoviaCorrectionActions();
        }

        internal IEnumerable<ICa> EcaItems => enoviaCorrectionActions;

        protected virtual IEnumerable<ICa> CreateEnoviaCorrectionActions()
        {
            return new List<ICa>() { Utility.GetCa2() };
        }
    }
}
