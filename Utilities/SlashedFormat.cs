using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csoft.EnoviaAtmIntegration.Utilities
{
    public class SlashedFormat : IFormattable
    {
        private readonly IFormattable origin;

        public SlashedFormat(IFormattable origin)
        { 
            this.origin = origin;
        }

        public string Format()
        {
            return origin.Format()
                .Replace(" ", "/")
                .Replace(".", "/")
                .Replace(":", "/");
        }
    }
}
