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
    /// creates list of integers from string
    /// </summary>
    public abstract class NumbersInterval
    {
        protected string input;

        protected NumbersInterval(string input)
        {
            this.input = input;
        }

        public abstract List<int> Split();
    }
}
