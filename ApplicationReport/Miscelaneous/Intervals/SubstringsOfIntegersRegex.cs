using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Tdms.Api;
using Tdms;

namespace Csoft.EnoviaAtmIntegration.Domain {
    /// <summary>
    /// encapsulates pattern @"\D+" to split string to substrings of integers
    /// </summary>
    public class SubstringsOfIntegersRegex : Regex
    {
        public SubstringsOfIntegersRegex() : base(@"\D+") { }
    }
}
