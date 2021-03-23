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
    public class NaturalNumbersInterval : NumbersInterval
    {
        public NaturalNumbersInterval(string input) : base(input) { }

        public override List<int> Split()
        {
            var ints = new IntegerNumbersInterval(input).Split();
            ints.RemoveAll(i => (i < 1));
            return ints;
        }
    }
}
