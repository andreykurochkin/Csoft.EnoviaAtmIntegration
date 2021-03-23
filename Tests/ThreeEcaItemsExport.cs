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
    internal class ThreeEcaItemsExport : TwoEcaItemsExport
    {
        internal ThreeEcaItemsExport(TDMSApplication application) : base(application) { }

        protected override IEnumerable<ICa> CreateEnoviaCorrectionActions()
        {
            return new List<ICa>()
            {
                Utility.GetCa2(),
                new Ca(Utility.GetCa2())
                {
                    Systems = $"LCB{Convert.ToChar(7)}LCT",
                    Npps = $"АЭС Руппур"
                }
            };
        }
    }
}
