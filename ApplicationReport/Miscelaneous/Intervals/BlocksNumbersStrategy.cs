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
    public abstract class BlocksNumbersStrategy
    {
        public bool IsAplicable => GetIsAplicable();
        protected abstract bool GetIsAplicable();
        public abstract List<int> GetNumbers();
    }
}
