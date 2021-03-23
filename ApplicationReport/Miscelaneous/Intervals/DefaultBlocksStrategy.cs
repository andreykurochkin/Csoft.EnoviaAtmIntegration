using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;

namespace Csoft.EnoviaAtmIntegration.Domain
{
    /// <summary>
    /// avoids evil of nullable types
    /// </summary>
    public class DefaultBlocksStrategy 
        : BlocksNumbersStrategy
    {
        public override List<int> GetNumbers()
        {
            return new List<int>();
        }

        protected override bool GetIsAplicable()
        {
            return true;
        }
    }
}
